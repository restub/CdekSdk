using System;
using System.Collections.Generic;
using System.Linq;
using CdekSdk.DataContracts;
using NUnit.Framework;
using Restub.DataContracts;

namespace CdekSdk.Tests
{
    [TestFixture]
    public class ErrorTests
    {
        [Test]
        public void ErrorResponseGetsConverterToAStringMessage()
        {
            Assert.That(CdekClient.GetErrorMessage(null), Is.EqualTo(string.Empty));
            Assert.That(CdekClient.GetErrorMessage(new List<Error>()), Is.EqualTo(string.Empty));

            var msg = CdekClient.GetErrorMessage(new List<Error>
            {
                new Error { Message = "Hello" },
                new Error { Message = "Cruel" },
                new Error { Message = "World" },
            });

            Assert.That(msg, Is.EqualTo("Hello. Cruel. World"));
        }

        [Test]
        public void EmptyResponseGetErrorsDoesntThrow()
        {
            // all DTO types implementing IHasErrors interface
            var errorEnabledResponseTypes =
                from t in typeof(CdekClient).Assembly.GetTypes()
                where t.GetInterfaces().Contains(typeof(IHasErrors))
                select t;

            var responseTypes = errorEnabledResponseTypes.ToArray();
            Assert.That(responseTypes, Is.Not.Null.Or.Empty);
            Assert.That(responseTypes.Length, Is.GreaterThan(3));

            foreach (var t in responseTypes)
            {
                var emptyResponse = Activator.CreateInstance(t) as IHasErrors;
                Assert.That(emptyResponse, Is.Not.Null);
                Assert.That(emptyResponse.GetErrorMessage(), Is.Not.Null);
                Assert.That(emptyResponse.HasErrors(), Is.False);
            }
        }
    }
}