using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectSearch
{
    public static class Mapping
    {
        public static Dictionary<string, string> Default => Combine(GreekStressedToUnstressed, LatinSpecialCharactersToEnglish);

        public static Dictionary<string, string> Combine(params Dictionary<string, string>[] mappings) 
            => mappings.Aggregate(new Dictionary<string, string>(), (m, n) => m.Concat(n).ToDictionary(x => x.Key, x => x.Value));

        private static Dictionary<string, string> AndAlso(this Dictionary<string, string> d, Func<string, string> f)
            => d.SelectMany(x => x.Key == f(x.Key)
                ? new[] { Tuple.Create(x.Key, x.Value) }
                : new[] { Tuple.Create(x.Key, x.Value), Tuple.Create(f(x.Key), f(x.Value)) })
                .ToDictionary(x => x.Item1, x => x.Item2);

        public static Dictionary<string, string> GreekStressedToUnstressed => new Dictionary<string, string>
        {
            ["ά"] = "α", ["έ"] = "ε", ["ή"] = "η", ["ί"] = "ι", ["ό"] = "ο", ["ύ"] = "υ", ["ώ"] = "ω",
            ["ϊ"] = "ι", ["ϋ"] = "υ",
            ["ΐ"] = "ι",
        }.AndAlso(x => x.ToUpperInvariant());


        public static Dictionary<string, string> LatinSpecialCharactersToEnglish => new Dictionary<string, string>
        {
            ["ä"] = "a", ["ë"] = "e", ["ï"] = "i", ["ö"] = "o", ["ü"] = "u",

            ["á"] = "a", ["ć"] = "c", ["é"] = "e", ["ǵ"] = "g", ["í"] = "i", ["j́"] = "j", ["ḱ"] = "k", ["ĺ"] = "l",
            ["ḿ"] = "m", ["ń"] = "n", ["ó"] = "o", ["ṕ"] = "p", ["ŕ"] = "r", ["ś"] = "s", ["ú"] = "u", ["ẃ"] = "w",
            ["ý"] = "y", ["ź"] = "z",

            ["ȧ"] = "a", ["ḃ"] = "b", ["ċ"] = "c", ["ḋ"] = "d", ["ė"] = "e", ["ḟ"] = "f", ["ġ"] = "g", ["ḧ"] = "h",
            ["ı"] = "i", ["ṁ"] = "m", ["ṅ"] = "n", ["ȯ"] = "o", ["ṙ"] = "r", ["ṡ"] = "s", ["ṫ"] = "t", ["ẇ"] = "w",
            ["ẋ"] = "x", ["ẏ"] = "y", ["ż"] = "z",

            ["ą"] = "a", ["ç"] = "c", ["ḑ"] = "d", ["ę"] = "e", ["ģ"] = "g", ["ḩ"] = "h", ["į"] = "i", ["ķ"] = "k",
            ["ļ"] = "l", ["ņ"] = "n", ["ǫ"] = "o", ["ŗ"] = "r", ["ş"] = "s", ["ţ"] = "t", ["ų"] = "u"
        }.AndAlso(x => x.ToUpperInvariant());
    }
}
