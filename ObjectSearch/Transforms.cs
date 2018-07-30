using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectSearch
{
    public static class Transform
    {
        public static Func<string, string> None() => x => x;
        public static Func<string, string> Default() => IgnoreCase().Then(Map(Mapping.Default));
        public static Func<string, string> IgnoreCase() => x => x.ToLowerInvariant();
        public static Func<string, string> Map(Dictionary<string, string> m) => s => m.Aggregate(s, (a, b) => a.Replace(b.Key, b.Value));
        public static Func<string, string> NoDoubleSpaces() => x =>
        {
            while (x.Contains("  "))
            {
                x = x.Replace("  ", " ");
            }
            return x;
        };
    }
}
