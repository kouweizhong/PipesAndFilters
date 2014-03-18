using Pipelines;

namespace Piplines2._0.Console
{
	public class WritePipelineContract : IPipelineContract
	{
		public int Value { get; set; }
		public string Output { get; set; }

		public WritePipelineContract(int input)
		{
			Value = input;
		}
	}
}
