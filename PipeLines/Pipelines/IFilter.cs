using System.Collections.Concurrent;

namespace Pipelines
{
	public interface IFilter
	{
		void Run(BlockingCollection<object> input, BlockingCollection<object> output);

	}
}
