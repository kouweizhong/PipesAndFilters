using Pipelines;

namespace Piplines2._0.Console
{
	public class WriteLineAppendNameFilter : Filter<WritePipelineContract>
	{
        string Name { get; set; }
	    public WriteLineAppendNameFilter(string name)
	    {
	        Name = name;
	    }

		public override void Run(FilterContext<WritePipelineContract> filterContext)
		{
			var input = filterContext.Input;
			input.Output = string.Format("{0} {1} - {2} ===>", input.Value, Name, input.Output);
			System.Console.WriteLine("{0} {1}", input.Value, Name);

			filterContext.PushToNext(input);
		}
	}

}
