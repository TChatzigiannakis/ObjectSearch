using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ObjectSearch
{
    public static class Selector
    {
        public static Func<T, string> ToString<T>() => o => o.ToString();

        public static IEnumerable<Func<T, string>> StringProperties<T>() => StringProperties<T>(BindingFlags.Public | BindingFlags.Instance);
        public static IEnumerable<Func<T, string>> StringProperties<T>(BindingFlags flags) =>
            typeof(T).GetProperties(flags)
                     .Where(x => x.CanRead)
                     .Where(x => x.PropertyType == typeof(string))
                     .Select<PropertyInfo, Func<T, string>>(p => o => (string)p.GetValue(o, new object[0]));
    }
}
