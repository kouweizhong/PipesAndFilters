using System;
using System.Collections.Concurrent;

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
		    var input = context.Input as WriteLineInput;
		    var write = string.Format("{0} {1} - {2} ===>", input.Value, Name, input.Index);
            Console.WriteLine("{0} {1}", context.Input.Value, Name);
            context.PushToNext(new WriteLineInput(write, 1));
		}
	}

}
