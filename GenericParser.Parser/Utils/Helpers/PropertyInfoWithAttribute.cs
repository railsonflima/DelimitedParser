using System.Reflection;

namespace GenericParser.Utils.Helpers
{
    public class PropertyInfoWithAttribute<TAttribute>
        where TAttribute : System.Attribute
    {
        public PropertyInfo Property { get; private set; }
        public TAttribute Attribute { get; private set; }
        private PropertyInfoWithAttribute(PropertyInfo property, TAttribute attribute)
        {
            Property = property;
            Attribute = attribute;
        }
        public static PropertyInfoWithAttribute<T> Factory<T>(PropertyInfo property, T attribute)
            where T : System.Attribute
        {
            return new PropertyInfoWithAttribute<T>(property, attribute);
        }
    }
}
