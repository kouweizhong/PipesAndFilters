using System.Collections.Generic;

namespace Pipelines
{
    public static class FilterInputExtension
    {
        public static T MapAs<T>(this object entity)
        {
            return (T) entity;
        }

        public static T MapAs<T>(this Dictionary<string, object> input) where T : new()
        {
            var returnValue = new T();
            foreach (var o in input)
            {
                var type = typeof (T);
                foreach (var value in input)
                {
                    var prop = type.GetProperty(value.Key);
                    if (prop != null)
                    {
                        prop.SetValue(returnValue, value.Value, null);
                    }
                }
            }
            return returnValue;
        }
    }
}
