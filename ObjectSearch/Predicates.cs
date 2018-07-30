using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectSearch
{
    public static class Predicate
    {
        public static Func<string, string, bool> Default() => False().Or(Contains());
        public static Func<string, string, bool> False() => (a, b) => false;
        public static Func<string, string, bool> Exact() => (a, b) => a == b;
        public static Func<string, string, bool> Contains() => (a, b) => a.Contains(b);
        public static Func<string, string, bool> StartsWith() => (a, b) => a.StartsWith(b);
    }
}
