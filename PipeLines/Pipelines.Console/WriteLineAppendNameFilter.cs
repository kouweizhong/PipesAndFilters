using System;

namespace Pipelines
{
	public class WriteLineAppendNameFilter : Filter
	{
        string Name { get; set; }
	    public WriteLineAppendNameFilter(string name)
	    {
	        Name = name;
	    }
		public override void Run(Context context)
		{
            var input = context.Input.MapAs<WriteLineInput>();
		    var write = string.Format("{0} {1} - {2} ===>", input.Value, Name, input.Index);
            Console.WriteLine("{0} {1}", context.Input, Name);

            context.PushToNext(new WriteLineInput(write, 1));
		}
	}

}
