using System;
using System.Reflection;
using Cosmos.Reflection;

namespace Alexinea.FastMember
{
    public class FastMemberValueGetter : IPropertyValueGetter
    {
        internal FastMemberValueGetter() { }

        public object Invoke(Type type, object that, string propertyName)
        {
            return that.GetPropertyValue(type, propertyName);
        }

        public object Invoke(Type type, object that, string propertyName, BindingFlags bindingAttr)
        {
            var allowNonPublicAccessors = 0 != (bindingAttr & BindingFlags.NonPublic);
            return that.GetPropertyValue(type, propertyName, allowNonPublicAccessors);
        }

        public static IPropertyValueGetter Instance { get; } = new FastMemberValueGetter();
    }
}