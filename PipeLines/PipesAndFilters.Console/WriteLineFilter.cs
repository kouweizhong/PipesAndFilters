namespace PipesAndFilters.Console
{
	public class WriteLineFilter : Filter<WritePipelineContract>
	{

		public override void Run(FilterContext<WritePipelineContract> filterContext)
		{
			var input = filterContext.Input;
			System.Console.WriteLine("{0}-{1}", input.Value, input.Value);
			filterContext.PushToNext(input);
		}
	}
}