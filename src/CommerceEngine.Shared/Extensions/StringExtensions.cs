using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceEngine.Shared.Extensions
{
   public static class StringExtensions
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
