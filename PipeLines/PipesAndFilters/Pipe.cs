using System.Collections.Concurrent;

namespace Pipelines
{
	public class Pipe<T> : IPipe<T> where T : IPipelineContract
	{
		public Pipe(IFilter<T> filter, BlockingCollection<T> buffer)
		{
			Filter = filter;
			Buffer = buffer;
		}

		public IFilter<T> Filter { get; set; }
		public BlockingCollection<T> Buffer { get; set; }
	}
}
