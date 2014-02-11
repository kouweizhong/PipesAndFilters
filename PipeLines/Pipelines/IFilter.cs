using System.Collections.Concurrent;

namespace Pipelines
{
	public interface IFilter
	{
		void Run(BlockingCollection<IFilterInput> input, BlockingCollection<IFilterInput> output);

	}
}
