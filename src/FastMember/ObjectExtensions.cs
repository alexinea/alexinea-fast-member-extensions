using System;
using System.Linq.Expressions;
using Alexinea.FastMember.Core;
using Cosmos.Exceptions;

namespace Alexinea.FastMember
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Get the value of the specified property name from the that.<br />
        /// 从对象中获取指定属性名称的值。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="that">Any <see cref="object"/></param>
        /// <param name="propertyName">Property name in this that</param>
        /// <param name="allowNonPublicAccessors"></param>
        /// <returns>Value of the specific property in this that</returns>
        public static object GetPropertyValue(this object that, Type type, string propertyName, bool allowNonPublicAccessors = false)
        {
            return Try.Create(() => type.CreateTypeAccessor(allowNonPublicAccessors)[that, propertyName])
                      .GetSafeValue(defaultVal: default);
        }

        /// <summary>
        /// Get the value of the specified property name from the that.<br />
        /// 从对象中获取指定属性名称的值。
        /// </summary>
        /// <param name="that">Any <see cref="object"/></param>
        /// <param name="propertyName">Property name in this that</param>
        /// <param name="allowNonPublicAccessors"></param>
        /// <returns>Value of the specific property in this that</returns>
        public static object GetPropertyValue<T>(this T that, string propertyName, bool allowNonPublicAccessors = false)
        {
            return Try.Create(() => typeof(T).CreateTypeAccessor(allowNonPublicAccessors)[that, propertyName])
                      .GetSafeValue(defaultVal: default);
        }

        /// <summary>
        /// Get the value of the specified property name from the that.<br />
        /// 从对象中获取指定属性名称的值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertySelector"></param>
        /// <param name="allowNonPublicAccessors"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static object GetPropertyValue<T>(this T that, Expression<Func<T, object>> propertySelector, bool allowNonPublicAccessors = false)
        {
            return Try.Create(() =>
            {
                var propertyName = PropertySelector.GetPropertyName(propertySelector);
                return typeof(T).CreateTypeAccessor(allowNonPublicAccessors)[that, propertyName];
            }).GetSafeValue(defaultVal: default);
        }

        /// <summary>
        /// Set a value to the specified property name in the that.<br />
        /// 向对象中的指定属性名称设置值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <param name="allowNonPublicAccessors"></param>
        public static void SetPropertyValue(this object that, Type type, string propertyName, object value, bool allowNonPublicAccessors = false)
        {
            Try.Invoke(() => { type.CreateTypeAccessor(allowNonPublicAccessors)[that, propertyName] = value; });
        }

        /// <summary>
        /// Set a value to the specified property name in the that.<br />
        /// 向对象中的指定属性名称设置值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <param name="allowNonPublicAccessors"></param>
        public static void SetPropertyValue<T>(this T that, string propertyName, object value, bool allowNonPublicAccessors = false)
        {
            Try.Invoke(() => { typeof(T).CreateTypeAccessor(allowNonPublicAccessors)[that, propertyName] = value; });
        }

        /// <summary>
        /// Set a value to the specified property name in the that.<br />
        /// 向对象中的指定属性名称设置值。
        /// </summary>
        /// <param name="that"></param>
        /// <param name="propertySelector"></param>
        /// <param name="value"></param>
        /// <param name="allowNonPublicAccessors"></param>
        /// <typeparam name="T"></typeparam>
        public static void SetPropertyValue<T>(this T that, Expression<Func<T, object>> propertySelector, object value, bool allowNonPublicAccessors = false)
        {
            Try.Invoke(() =>
            {
                var propertyName = PropertySelector.GetPropertyName(propertySelector);
                typeof(T).CreateTypeAccessor(allowNonPublicAccessors)[that, propertyName] = value;
            });
        }
    }
}