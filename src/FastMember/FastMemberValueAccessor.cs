using System;
using System.Reflection;
using Cosmos.Reflection;

namespace Alexinea.FastMember
{
    public class FastMemberValueAccessor : IPropertyValueAccessor
    {
        public FastMemberValueAccessor(object instance, Type type)
        {
            _instance = instance;
            _type = type;
        }

        private readonly Type _type;
        private readonly object _instance;

        public object GetValue(string propertyName)
        {
            return _instance.GetPropertyValue(_type, propertyName);
        }

        public object GetValue(string propertyName, BindingFlags bindingAttr)
        {
            var allowNonPublicAccessors = 0 != (bindingAttr & BindingFlags.NonPublic);
            return _instance.GetPropertyValue(_type, propertyName, allowNonPublicAccessors);
        }

        public void SetValue(string propertyName, object value)
        {
            value.SetPropertyValue(_type, propertyName, value);
        }

        public void SetValue(string propertyName, BindingFlags bindingAttr, object value)
        {
            var allowNonPublicAccessors = 0 != (bindingAttr & BindingFlags.NonPublic);
            value.SetPropertyValue(_type, propertyName, value, allowNonPublicAccessors);
        }

        public static IPropertyValueAccessor Of<T>(T instance) => new FastMemberValueAccessor<T>(instance);

        public static IPropertyValueAccessor Of(object instance, Type type) => new FastMemberValueAccessor(instance, type);
    }

    public class FastMemberValueAccessor<T> : IPropertyValueAccessor
    {
        public FastMemberValueAccessor(object instance)
        {
            _instance = instance;
        }

        private readonly Type _type = typeof(T);
        private readonly object _instance;

        public object GetValue(string propertyName)
        {
            return _instance.GetPropertyValue(_type, propertyName);
        }

        public object GetValue(string propertyName, BindingFlags bindingAttr)
        {
            var allowNonPublicAccessors = 0 != (bindingAttr & BindingFlags.NonPublic);
            return _instance.GetPropertyValue(_type, propertyName, allowNonPublicAccessors);
        }

        public void SetValue(string propertyName, object value)
        {
            value.SetPropertyValue(_type, propertyName, value);
        }

        public void SetValue(string propertyName, BindingFlags bindingAttr, object value)
        {
            var allowNonPublicAccessors = 0 != (bindingAttr & BindingFlags.NonPublic);
            value.SetPropertyValue(_type, propertyName, value, allowNonPublicAccessors);
        }
    }
}