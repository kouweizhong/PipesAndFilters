    using System.Collections.Concurrent;

namespace PipesAndFilters
{
    public class FilterContext<T> where T : IPipelineContract
    {
        public T Input { get; private set; }
        private BlockingCollection<T> Output { get; set; }

        public FilterContext(T input, BlockingCollection<T> output)
        {
            Input = input;
            Output = output;
        }
        public void PushToNext(T input)
        {
            Output.Add(input);
        }
    }
}
