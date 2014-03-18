namespace PipesAndFilters.Console
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
