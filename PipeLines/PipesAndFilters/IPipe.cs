using System.Collections.Concurrent;

namespace Pipelines
{
	public interface IPipe<T> where T : IPipelineContract
	{
		IFilter<T> Filter { get; set; }
		BlockingCollection<T> Buffer { get; set; }
	}
}
