using System.Collections.Generic;
using System.Linq;

namespace PipesAndFilters.Console
{
	class Program
	{
		static void Main()
		{
			var sendFilter = new SendFilter();
			var inputInts = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
			var input = inputInts.Select(i => new WritePipelineContract(i));
			Pipeline<WritePipelineContract>.StartNew(sendFilter, input, 100)
				.Then(new WriteLineAppendNameFilter("Paul Smelser"), 100)
				.Then(new WriteLineAppendNameFilter("Melinda Chen"), 100)
				.Then(new WriteLineAppendNameFilter("William Smelser"), 100)
				.Then(new WriteLineAppendNameFilter("Michael Smelser"), 100)
				.Then(new WriteLineFilter(), 100).Run();

			System.Console.ReadKey();
		}
	}
}
