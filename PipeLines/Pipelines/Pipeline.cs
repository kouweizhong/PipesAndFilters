using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pipelines
{
    public class Pipeline : IPipeline
    {
		Queue<Pipe> Filters { get; set; }
		BlockingCollection<object> Input { get; set; }

		private Pipeline(IFilter filter, BlockingCollection<object> input, BlockingCollection<object> firstOutput)
		{
			Filters = new Queue<Pipe>();
			Filters.Enqueue(new Pipe(filter, firstOutput));
			Input = input;
		}

		public static Pipeline StartNew(IFilter filter, IEnumerable<object> input, int bufferSize)
		{
			var enumerable = input as object[] ?? input.ToArray();
			var input2 = new BlockingCollection<object>(enumerable.Count());
			foreach (var o in enumerable)
			{
				input2.Add(o);
			}
			input2.CompleteAdding();
			return new Pipeline(filter, input2, new BlockingCollection<object>(bufferSize));
		}

		public Pipeline Then(IFilter filter, int bufferSize)
		{
			Filters.Enqueue(new Pipe(filter, new BlockingCollection<object>(bufferSize)));
			return this;
		}

		public void Run()
		{
			var taskCount = Filters.Count;
			var stages = new Task[taskCount];
			var lastJob = Filters.Dequeue();
			var factory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);

			Pipe prevJob = lastJob;
			stages[0] = factory.StartNew(() => prevJob.Filter.Run(Input, prevJob.Buffer));
			for (var i = 1; i != taskCount; i++)
			{
				var job = Filters.Dequeue();
				Pipe localPrevJob = lastJob;
				stages[i] = factory.StartNew(() => job.Filter.Run(localPrevJob.Buffer, job.Buffer));
				lastJob = job;
			}
			Task.WaitAll(stages);
		}
    }
}
