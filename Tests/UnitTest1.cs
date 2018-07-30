using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectSearch;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var o = new TestObject { A = "Hey!", B = "What?" };

            var t = Transform.Default();
            var p = Predicate.StartsWith();
            var s = Search.CreateForType<TestObject>()
                          .Add(x => x.ToString(), t, p)
                          .Add(Selector.StringProperties<TestObject>(), t, p);

            var v = s(o, "hey");
            Assert.IsTrue(v);

            var u = s(o, "what");
            Assert.IsTrue(u);
        }
    }

    public class TestObject
    {
        public string A { get; set; }
        public string B { get; set; }

        public override string ToString() => A;
    }
}
