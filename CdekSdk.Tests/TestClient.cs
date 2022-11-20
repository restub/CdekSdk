using NUnit.Framework;

namespace CdekSdk.Tests
{
    public class TestClient : CdekClient
    {
        public TestClient() : base()
        {
            Tracer = TestContext.Progress.WriteLine;
        }
    }
}
