﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CdekApi;
using CdekApi.DataContracts;
using CdekApi.Toolbox;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CdekApiTests
{
    [TestFixture]
    public class ErrorTests
    {
        [Test]
        public void ErrorResponseGetsConverterToAStringMessage()
        {
            Assert.That(CdekClient.GetErrorMessage(null), Is.EqualTo(string.Empty));
            Assert.That(CdekClient.GetErrorMessage(new ErrorResponse()), Is.EqualTo(string.Empty));

            var msg = CdekClient.GetErrorMessage(new ErrorResponse
            {
                Errors = new List<Error>
                {
                    new Error { Message = "Hello" },
                    new Error { Message = "Cruel" },
                    new Error { Message = "World" },
                }
            });

            Assert.That(msg, Is.EqualTo("Hello. Cruel. World"));
        }
    }
}