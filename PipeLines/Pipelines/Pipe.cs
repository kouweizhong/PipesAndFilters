using System.Collections.Concurrent;

namespace Pipelines
{
	public class Pipe : IPipe
	{
		public Pipe(IFilter filter, BlockingCollection<IFilterInput> buffer)
		{
			Filter = filter;
			Buffer = buffer;
		}

		public IFilter Filter { get; set; }
		public BlockingCollection<IFilterInput> Buffer { get; set; }
	}
}
