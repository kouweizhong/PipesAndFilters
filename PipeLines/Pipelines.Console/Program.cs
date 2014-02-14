using System.Collections.Generic;

namespace Pipelines
{
	public class Program
	{
		static void Main()
		{
			var sendFilter = new SendFilter();

			Pipeline.StartNew(sendFilter, new List<object> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 100)
                .Then(new WriteLineAppendNameFilter("Paul Smelser"), 100)
                .Then(new WriteLineAppendNameFilter("Melinda Chen"), 100)
                .Then(new WriteLineAppendNameFilter("William Smelser"), 100)
                .Then(new WriteLineFilter(), 100)
                .Then(new RegexReplaceFilter(), 100).Run();

			System.Console.ReadKey();
		}

		//private static void Run()
		//{
		//	var originalImages = new BlockingCollection<string>(10) {"Hello", "Hello", "Hello", "Hello", "Hello", "Hello"};
		//	originalImages.CompleteAdding();
		//	var thumbnailImages = new BlockingCollection<string>(10);
		//	var f = new TaskFactory(TaskCreationOptions.LongRunning,
		//		TaskContinuationOptions.None);
		//	var loadTask = f.StartNew(() => Load(originalImages, thumbnailImages))
		//	;
		//	var scaleTask = f.StartNew(() =>
		//		Write(thumbnailImages, new BlockingCollection<string>()))
		//	;

		//	Task.WaitAll(loadTask, scaleTask);
		//}

		//public static void Load(BlockingCollection<string> input, BlockingCollection<string> output)
		//{
		//	foreach (var item in input)
		//	{
		//		output.PushToNext(item + "Change");
		//	}
		//}

		//public static void Write(BlockingCollection<string> input, BlockingCollection<string> output)
		//{
		//	foreach (var item in input)
		//	{
		//		Console.WriteLine(item);
		//	}
		//}
	}
}
