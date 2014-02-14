    using System.Collections.Concurrent;

namespace Pipelines
{
    public class Context
    {
        public object Input { get; private set; }
        private BlockingCollection<object> Output { get; set; }

        public Context(object input, BlockingCollection<object> output)
        {
            Input = input;
            Output = output;
        }
        public void PushToNext(object input)
        {
            Output.Add(input);
        }
    }
}
