using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectSearch
{
    public static class Search
    {
        private static bool CompareStrings(string s1, string s2, Func<string, string> transform, Func<string, string, bool> predicate) 
            => predicate(transform(s1), transform(s2));

        public static Func<T, string, bool> CreateForType<T>() 
            => (o, s) => false;

        public static Func<T, string, bool> Add<T>(this Func<T, string, bool> p, Func<T, string> selector, Func<string, string> transform, Func<string, string, bool> predicate)
            => p.Or((o, s) => CompareStrings(selector(o), s, transform, predicate));

        public static Func<T, string, bool> Add<T>(this Func<T, string, bool> p, IEnumerable<Func<T, string>> selector, Func<string, string> transform, Func<string, string, bool> predicate)
            => selector.Aggregate(p, (a, b) => a.Add(b, transform, predicate));
    }
}
