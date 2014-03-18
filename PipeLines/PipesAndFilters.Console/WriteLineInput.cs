namespace PipesAndFilters.Console
{
	public class WriteLineInput
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
