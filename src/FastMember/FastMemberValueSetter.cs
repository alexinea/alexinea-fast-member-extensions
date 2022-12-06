using System;
using System.Reflection;
using Cosmos.Reflection;

namespace Alexinea.FastMember
{
    public class FastMemberValueSetter : IPropertyValueSetter
    {
        internal FastMemberValueSetter() { }

        public void Invoke(Type type, object that, string propertyName, object value)
        {
            that.SetPropertyValue(type, propertyName, value);
        }

        public void Invoke(Type type, object that, string propertyName, BindingFlags bindingAttr, object value)
        {
            var allowNonPublicAccessors = 0 != (bindingAttr & BindingFlags.NonPublic);
            that.SetPropertyValue(type, propertyName, value, allowNonPublicAccessors);
        }

        public static IPropertyValueSetter Instance { get; } = new FastMemberValueSetter();
    }
}