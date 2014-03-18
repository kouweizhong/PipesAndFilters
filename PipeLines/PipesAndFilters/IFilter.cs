using System.Collections.Concurrent;

namespace PipesAndFilters
{
	public interface IFilter<T> where T : IPipelineContract
	{
		void Run(BlockingCollection<T> input, BlockingCollection<T> output);

	}
}
