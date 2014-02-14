namespace Pipelines
{
	public class WriteLineFilter : Filter
	{
		public override void Run(Context context)
		{
            var input = context.Input.MapAs<WriteLineInput>();
			System.Console.WriteLine("{0}-{1}",input.Index, input.Value);
			context.PushToNext(new RegexReplaceFilterInput{InputString = (string) input.Value, RegexPattern = "^\\d*"});
		}
	}
}