using System.Collections.Concurrent;

namespace Pipelines
{
	public abstract class Filter<T> : IFilter<T> where T : IPipelineContract
	{
		public abstract void Run(FilterContext<T> filterContext);

		public void Run(BlockingCollection<T> input, BlockingCollection<T> output)
		{
			try
			{
				foreach (var item in input.GetConsumingEnumerable())
				{
					Run(new FilterContext<T>(item, output));
				}
			}
			finally
			{
				output.CompleteAdding();
			}
		}
	}
}
