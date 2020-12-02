using System;
using FastMember;

namespace Alexinea.FastMember.Core
{
    internal static class TypeAccessorExtensions
    {
        /// <summary>
        /// Create TypeAccessor
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TypeAccessor CreateTypeAccessor(this Type type)
        {
            return TypeAccessorCache.Touch(type);
        }
        
        /// <summary>
        /// Create TypeAccessor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="allowNonPublicAccessors"></param>
        /// <returns></returns>
        public static TypeAccessor CreateTypeAccessor(this Type type, bool allowNonPublicAccessors)
        {
            return TypeAccessorCache.Touch(type, allowNonPublicAccessors);
        }
    }
}