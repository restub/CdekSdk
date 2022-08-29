using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdekApi;
using NUnit.Framework;

namespace CdekApiTests
{
    public class TestClient : CdekClient
    {
        public TestClient()
            :base(SandboxApiUrl, Credentials.TestCredentials)
        {
            Tracer = TestContext.Progress.WriteLine;
        }
    }
}
