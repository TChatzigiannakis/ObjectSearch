using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectSearch
{
    public static class Func
    {
        internal static Func<T1, T2, bool> Any<T1, T2>(IEnumerable<Func<T1, T2, bool>> functions) => (o, s) => functions.Any(p => p(o, s));
        internal static Func<T1, T2, bool> Any<T1, T2>(params Func<T1, T2, bool>[] functions) => Any(functions as IEnumerable<Func<T1, T2, bool>>);
        public static Func<T1, T2, bool> Or<T1, T2>(this Func<T1, T2, bool> p, Func<T1, T2, bool> q) => Any(p, q);

        private static Func<T, T> Id<T>() => o => o;
        internal static Func<T, T> Compose<T>(IEnumerable<Func<T, T>> functions) => functions.Aggregate(Id<T>(), (a, b) => x => b(a(x)));
        internal static Func<T, T> Compose<T>(params Func<T, T>[] functions) => Compose(functions as IEnumerable<Func<T, T>>);
        public static Func<T, T> Then<T>(this Func<T, T> f, Func<T, T> g) => Compose(f, g);
    }
}
