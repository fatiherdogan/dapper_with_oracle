using System.ComponentModel;

namespace Example.Project.ToolKit.Helpers
{
    public static class ExtensionMethods
    {
        public static T ConvertTo<T>(this object obj)
        {
            T result = default(T);
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null && converter.CanConvertFrom(obj.GetType()))
            {
                result = (T)converter.ConvertFrom(null, System.Globalization.CultureInfo.InvariantCulture, obj);
            }
            else
            {
                converter = TypeDescriptor.GetConverter(obj);
                if (converter != null && converter.CanConvertTo(obj.GetType()))
                {
                    result = (T)converter.ConvertTo(null, System.Globalization.CultureInfo.InvariantCulture, obj, obj.GetType());
                }
            }
            return result;
        }
    }
}
