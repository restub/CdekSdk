using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdekSdk;
using NUnit.Framework;

namespace CdekSdk.Tests
{
    public class TestClient : CdekClient
    {
        public TestClient()
            :base(SandboxApiUrl, CdekCredentials.TestCredentials)
        {
            Tracer = TestContext.Progress.WriteLine;
        }
    }
}
