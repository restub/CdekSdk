using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CdekApi.Toolbox;
using NUnit.Framework;
using RestSharp;

namespace CdekApiTests
{
    [TestFixture]
    public class ParameterHelperTests
    {
        [Test]
        public void DefaultValueTests()
        {
            Assert.That(ParameterHelper.GetDefaultValue<string>(), Is.EqualTo(default(string)));
            Assert.That(ParameterHelper.GetDefaultValue<int>(), Is.EqualTo(default(int)));
            Assert.That(ParameterHelper.GetDefaultValue<char?>(), Is.EqualTo(default(char?)));
            Assert.That(ParameterHelper.GetDefaultValue<ParameterHelperTests>(), Is.EqualTo(default(ParameterHelperTests)));

            Assert.That(typeof(string).GetDefaultValue(), Is.EqualTo(default(string)));
            Assert.That(typeof(int).GetDefaultValue(), Is.EqualTo(default(int)));
            Assert.That(typeof(char?).GetDefaultValue(), Is.EqualTo(default(char?)));
            Assert.That(typeof(ParameterHelperTests).GetDefaultValue(), Is.EqualTo(default(ParameterHelperTests)));
        }

        private class StubRequest : StubRequestBase
        {
            public Dictionary<string, Tuple<object, ParameterType>> Params { get; } = new Dictionary<string, Tuple<object, ParameterType>>();

            public override IRestRequest AddParameter(string name, object value, ParameterType type)
            {
                Params[name] = Tuple.Create(value, type);
                return this;
            }
        }

        public class Request
        {
            [DataMember(Name = "string")]
            public string String { get; set; }

            [DataMember(Name = "int")]
            public int Int { get; set; }

            [DataMember(Name = "strings")]
            public string[] Strings{ get; set; }

            [DataMember(Name = "integers")]
            public int[] Integers { get; set; }

            [DataMember(Name = "important", IsRequired = true)]
            public bool Important { get; set; }
        }

        [Test]
        public void NoParameters()
        {
            var req = new StubRequest();
            req.AddParameters(null, ParameterType.QueryString);
            Assert.That(req.Params.Count, Is.EqualTo(0));

            req.AddParameters(new Request(), ParameterType.QueryString);
            Assert.That(req.Params.Count, Is.EqualTo(1));
            Assert.That(req.Params["important"], Is.EqualTo(Tuple.Create((object)false, ParameterType.QueryString)));
        }

        [Test]
        public void SimpleParameters()
        {
            var req = new StubRequest();
            req.AddParameters(new Request { String = "test", Int = 32 }, ParameterType.QueryString);
            Assert.That(req.Params.Count, Is.EqualTo(3));
            Assert.That(req.Params["string"], Is.EqualTo(Tuple.Create("test", ParameterType.QueryString)));
            Assert.That(req.Params["int"], Is.EqualTo(Tuple.Create(32, ParameterType.QueryString)));
            Assert.That(req.Params["important"], Is.EqualTo(Tuple.Create(false, ParameterType.QueryString)));
        }

        [Test]
        public void ArrayParameters()
        {
            var req = new StubRequest();
            req.AddParameters(new Request { Strings = new[] { "one", "two", "three" } }, ParameterType.UrlSegment);
            Assert.That(req.Params.Count, Is.EqualTo(2));
            Assert.That(req.Params["strings"], Is.EqualTo(Tuple.Create("one,two,three", ParameterType.UrlSegment)));
            Assert.That(req.Params["important"], Is.EqualTo(Tuple.Create(false, ParameterType.UrlSegment)));

            req.AddParameters(new Request { Integers = new int[0] }, ParameterType.UrlSegment);
            Assert.That(req.Params.Count, Is.EqualTo(3));
            Assert.That(req.Params["integers"], Is.EqualTo(Tuple.Create(string.Empty, ParameterType.UrlSegment)));
            Assert.That(req.Params["important"], Is.EqualTo(Tuple.Create(false, ParameterType.UrlSegment)));

            req.AddParameters(new Request { Integers = new[] { 3, 2, 1 } }, ParameterType.UrlSegment);
            Assert.That(req.Params.Count, Is.EqualTo(3));
            Assert.That(req.Params["integers"], Is.EqualTo(Tuple.Create("3,2,1", ParameterType.UrlSegment)));
            Assert.That(req.Params["important"], Is.EqualTo(Tuple.Create(false, ParameterType.UrlSegment)));

            req.AddParameters(new Request { Important = true }, ParameterType.Cookie);
            Assert.That(req.Params.Count, Is.EqualTo(3));
            Assert.That(req.Params["important"], Is.EqualTo(Tuple.Create(true, ParameterType.Cookie)));
        }
    }
}