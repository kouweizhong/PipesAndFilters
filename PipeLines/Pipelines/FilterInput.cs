namespace Pipelines
{
	public class FilterInput : IFilterInput
	{
		public FilterInput(object value)
		{
			Value = value;
		}

		public object Value { get; set; }
	}
}
