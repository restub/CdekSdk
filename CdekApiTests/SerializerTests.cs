using System;
using System.Runtime.Serialization;
using CdekApi.Toolbox;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CdekApiTests
{
    [TestFixture]
    public class SerializerTests
    {
        private string Serialize<T>(T dto)
        {
            var ss = new NewtonsoftSerializer();
            return ss.Serialize(dto);
        }

        private T Deserialize<T>(string json, T _ = default(T))
        {
            var ss = new NewtonsoftSerializer();
            return ss.Deserialize<T>(json);
        }

        [Test]
        public void SerializationRoundtrip()
        {
            var obj = new
            {
                str = "string",
                num = 123,
                dec = 456.78,
                date = new DateTime(2022, 08, 11, 13, 06, 00),
            };

            var json = Serialize(obj);
            Assert.That(json, Is.Not.Empty);
            Assert.That(json, Is.EqualTo("{\"str\":\"string\",\"num\":123,\"dec\":456.78,\"date\":\"2022-08-11T13:06:00+0300\"}"));

            var des = Deserialize(json, obj);
            Assert.That(des, Is.Not.Null);
            Assert.That(des, Is.EqualTo(obj));
        }

        [DataContract]
        public class NoTime
        {
            [DataMember(Name = "d"), JsonConverter(typeof(DateOnlyConverter))]
            public DateTime Date { get; set; }
        }

        [Test]
        public void DateTimeSerialization()
        {
            var obj = new NoTime { Date = new DateTime(2022, 08, 11) };
            var json = Serialize(obj);
            Assert.That(json, Is.EqualTo("{\"d\":\"2022-08-11\"}"));

            var date = Deserialize<NoTime>(json);
            Assert.That(date, Is.Not.Null);
            Assert.That(date.Date, Is.EqualTo(new DateTime(2022, 08, 11)));
        }
    }
}