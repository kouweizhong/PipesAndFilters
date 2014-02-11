using System;
using System.Threading;

namespace Pipelines
{
	public class SendFilter : Filter
	{
		public override void Run(Context context)
		{
			var outValue = new WriteLineInput(PhraseSource(context.Input));
			context.PushToNext(outValue);
		}

		static string PhraseSource(IFilterInput input)
		{
            Thread.Sleep(TimeSpan.FromMilliseconds(8));
		    return string.Format("{0}-{1}", input.Value, DateTime.UtcNow.ToString("O"));
		}
	}
}
