using System;
using System.Threading;

namespace Pipelines
{
	public class SendFilter : Filter
	{
		public override void Run(Context context)
		{
			var outValue = new WriteLineInput(PhraseSource(context.Input), (int) context.Input);
			context.PushToNext(outValue);
		}

		static string PhraseSource(object input)
		{
		    return $"{input}-{DateTime.UtcNow.ToString("O")}";
		}
	}
}
