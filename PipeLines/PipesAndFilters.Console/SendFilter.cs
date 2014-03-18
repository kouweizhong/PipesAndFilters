using System;
using System.Threading;

namespace PipesAndFilters.Console
{
	public class SendFilter : Filter<WritePipelineContract>
	{
		//public override void Run(Context context)
		//{
		//	var outValue = new WriteLineInput(PhraseSource(context.Input), (int) context.Input);
		//	context.PushToNext(outValue);
		//}

		static string PhraseSource(object input)
		{
            Thread.Sleep(TimeSpan.FromMilliseconds(8));
		    return string.Format("{0}-{1}", input, DateTime.UtcNow.ToString("O"));
		}

		public override void Run(FilterContext<WritePipelineContract> filterContext)
		{
			filterContext.Input.Output = PhraseSource(filterContext.Input);
			filterContext.PushToNext(filterContext.Input);
		}
	}
}
