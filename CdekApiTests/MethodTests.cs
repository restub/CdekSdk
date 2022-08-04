using System.Text;
using CdekApi;
using CdekApi.DataContracts;
using NUnit.Framework;

namespace CdekApiTests
{
    [TestFixture]
    public class MethodTests
    {
        private TestClient Client { get; } = new TestClient();

        [Test]
        public void BadInput()
        {
            var ex = Assert.Throws<CdekApiException>(() => Client.GetRegions(new RegionRequest { Page = 3 }));
            Assert.That(ex, Is.Not.Null);

            // reports something like: [size] is empty
            Assert.That(ex.Message, Contains.Substring("size"));
            Assert.That(ex.Message, Contains.Substring("empty"));
        }

        [Test]
        public void GetRegions()
        {
            var regions = Client.GetRegions(new RegionRequest { Size = 5 });
            Assert.That(regions, Is.Not.Null);
            Assert.That(regions.Length, Is.EqualTo(5));
        }

        [Test]
        public void GetCities()
        {
            var cities = Client.GetCities(new CityRequest { Size = 5 });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(5));
        }
    }
}