using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pipelines
{
    public class Pipeline<T> : IPipeline<T> where T : IPipelineContract
    {
		Queue<Pipe<T>> Filters { get; set; }
		BlockingCollection<T> Input { get; set; }

		private Pipeline(IFilter<T> filter, BlockingCollection<T> input, BlockingCollection<T> firstOutput)
		{
			Filters = new Queue<Pipe<T>>();
			Filters.Enqueue(new Pipe<T>(filter, firstOutput));
			Input = input;
		}

		public static Pipeline<T> StartNew(IFilter<T> filter, IEnumerable<T> input, int bufferSize)
		{
			return CreateNew(filter, input, bufferSize);
		}

		public static Pipeline<T> CreateNew(IFilter<T> filter, IEnumerable<T> input, int bufferSize)
		{
			var enumerable = input as T[] ?? input.ToArray();
			var input2 = new BlockingCollection<T>(enumerable.Count());
			foreach (var o in enumerable)
			{
				input2.Add(o);
			}
			input2.CompleteAdding();
			return new Pipeline<T>(filter, input2, new BlockingCollection<T>(bufferSize));
		}

		public Pipeline<T> Then(IFilter<T> filter, int bufferSize)
		{
			Enqueue(filter, bufferSize);
			return this;
		}

	    public void Enqueue(IFilter<T> filter, int bufferSize)
	    {
			Filters.Enqueue(new Pipe<T>(filter, new BlockingCollection<T>(bufferSize)));
	    } 

		public void Run()
		{
			var taskCount = Filters.Count;
			var stages = new Task[taskCount];
			var lastJob = Filters.Dequeue();
			var factory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);

			Pipe<T> prevJob = lastJob;
			stages[0] = factory.StartNew(() => prevJob.Filter.Run(Input, prevJob.Buffer));
			for (var i = 1; i != taskCount; i++)
			{
				var job = Filters.Dequeue();
				Pipe<T> localPrevJob = lastJob;
				stages[i] = factory.StartNew(() => job.Filter.Run(localPrevJob.Buffer, job.Buffer));
				lastJob = job;
			}
			Task.WaitAll(stages);
		}
    }
}
