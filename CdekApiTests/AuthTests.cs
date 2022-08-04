using System.Text;
using CdekApi;
using NUnit.Framework;

namespace CdekApiTests
{
    [TestFixture]
    public class AuthTests
    {
        [Test]
        public void CdekClientAuthenticates()
        {
            var trace = new StringBuilder();
            var client = new CdekClient(CdekClient.SandboxApiUrl, Credentials.TestCredentials);
            client.Tracer = (format, args) => trace.AppendFormat(format, args);

            var regions = client.GetRegions();
            Assert.That(regions, Is.Not.Null);

            var log = trace.ToString();
            Assert.That(log, Is.Not.Empty);
            Assert.That(log, Contains.Substring("oauth/token?parameters"));
            Assert.That(log, Contains.Substring("AuthToken"));
            TestContext.Progress.WriteLine(log);
        }
    }
}