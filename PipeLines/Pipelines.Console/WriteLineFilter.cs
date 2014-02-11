using System.Collections.Concurrent;

namespace Pipelines
{
	public class WriteLineFilter : Filter
	{
		public override void Run(Context context)
		{
			System.Console.WriteLine(context.Input.Value);
			context.PushToNext(context.Input);
		}
	}
}
