using System.Collections.Concurrent;

namespace Pipelines
{
	public abstract class Filter : IFilter
	{
		public abstract void Run(Context context);

		public void Run(BlockingCollection<IFilterInput> input, BlockingCollection<IFilterInput> output)
		{
			try
			{
				foreach (var item in input.GetConsumingEnumerable())
				{
					Run(new Context(item, output));
				}
			}
			finally
			{
				output.CompleteAdding();
			}
		}
	}
}
