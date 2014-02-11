namespace Pipelines
{
	public class WriteLineInput : IFilterInput
	{
		public WriteLineInput(string value)
		{
			Value = value;
		}

		public object Value { get; set; }
	}
}
