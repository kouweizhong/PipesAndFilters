namespace Pipelines
{
	public class WriteLineInput : IFilterInput
	{
		public WriteLineInput(string value, int index)
		{
			Value = value;
		    Index = index;
		}

		public object Value { get; set; }
        public int Index { get; set; }
	}
}
