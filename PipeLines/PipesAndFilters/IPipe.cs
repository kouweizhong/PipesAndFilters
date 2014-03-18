using System.Collections.Concurrent;

namespace PipesAndFilters
{
	public interface IPipe<T> where T : IPipelineContract
	{
		IFilter<T> Filter { get; set; }
		BlockingCollection<T> Buffer { get; set; }
	}
}
