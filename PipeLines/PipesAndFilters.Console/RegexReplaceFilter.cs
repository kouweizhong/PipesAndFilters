//using System;
//using System.Text.RegularExpressions;

//namespace Pipelines
//{
//	public class RegexReplaceFilter : Filter
//	{
//		public override void Run(Context context)
//		{
//			var input = context.Input.MapAs<RegexReplaceFilterInput>();
//			var rgx = new Regex(input.RegexPattern);
//			var result = rgx.Replace(input.InputString, "Steve Mathieu");
//			Console.WriteLine(result);
//		}
//	}
//}
