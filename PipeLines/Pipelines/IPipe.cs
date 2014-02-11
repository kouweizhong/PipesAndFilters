using System.Collections.Concurrent;

namespace Pipelines
{
	public interface IPipe
	{
		IFilter Filter { get; set; }
		BlockingCollection<IFilterInput> Buffer { get; set; }
	}
}
