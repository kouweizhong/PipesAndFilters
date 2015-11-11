using System.Collections.Generic;

namespace Pipelines
{
	public class Program
	{
		static void Main()
		{
			Pipeline.StartNew(new SendFilter(), new List<object> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 100)
                .Then(new WriteLineAppendNameFilter("Paul Smelser"), 100)
                .Then(new WriteLineAppendNameFilter("Melinda Chen"), 100)
                .Then(new WriteLineAppendNameFilter("William Smelser"), 100)
                .Then(new WriteLineFilter(), 100)
                .Then(new RegexReplaceFilter(), 100)
                .Run();

			System.Console.ReadKey();
		}
	}
}
