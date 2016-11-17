using System.ComponentModel;

namespace Web.Common
{
    public class PrimitiveTypeParser
    {
        public static T Parse<T>(string valueAsString)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            var result = converter.ConvertFromString(valueAsString);
            return (T)result;
        }
    }
}
