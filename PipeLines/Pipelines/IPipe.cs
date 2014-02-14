using System.Collections.Concurrent;

namespace Pipelines
{
	public interface IPipe
	{
		IFilter Filter { get; set; }
		BlockingCollection<object> Buffer { get; set; }
	}
}
