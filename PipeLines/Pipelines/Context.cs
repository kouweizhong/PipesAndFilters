using System.Collections.Concurrent;

namespace Pipelines
{
    public class Context
    {
        public IFilterInput Input { get; private set; }
        private BlockingCollection<IFilterInput> Output { get; set; }

        public Context(IFilterInput input, BlockingCollection<IFilterInput> output)
        {
            Input = input;
            Output = output;
        }
        public void PushToNext(IFilterInput input)
        {
            Output.Add(input);
        }
    }
}
