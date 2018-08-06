using System;

namespace GenericParser.Utils.Extensions
{
    public static class ConvertExtensions
    {
        public static object ChangeTypeSafe(this object objToConvert, Type type, object defaultValue)
        {
            try
            {
                return Convert.ChangeType(objToConvert, type);
            }
            catch
            {
                return Convert.ChangeType(defaultValue, type);
            }
        }
    }
}
