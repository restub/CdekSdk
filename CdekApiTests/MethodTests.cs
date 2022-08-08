using System.Linq;
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

            regions = Client.GetRegions(new RegionRequest { Page = 2, Size = 3 });
            Assert.That(regions, Is.Not.Null);
            Assert.That(regions.Length, Is.EqualTo(3));

            regions = Client.GetRegions(new RegionRequest { CountryCodes = new[] { "JP" }, Size = 10 });
            Assert.That(regions, Is.Not.Null);
            Assert.That(regions.Length, Is.EqualTo(10));
            Assert.That(regions.Select(r => r.CountryCode).First(), Is.EqualTo("JP"));
            Assert.That(regions.Select(r => r.CountryCode).Distinct().Count(), Is.EqualTo(1));

            regions = Client.GetRegions(new RegionRequest { CountryCodes = new[] { "FR", "JP" }, Size = 10 });
            Assert.That(regions, Is.Not.Null);
            Assert.That(regions.Length, Is.EqualTo(10));
            Assert.That(regions.Select(r => r.CountryCode).Distinct().Count(), Is.AnyOf(1, 2));
        }

        [Test]
        public void GetCities()
        {
            var cities = Client.GetCities(new CityRequest { Size = 5 });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(5));

            cities = Client.GetCities(new CityRequest { Page = 2, Size = 3 });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(3));

            cities = Client.GetCities(new CityRequest { CountryCodes = new[] { "CN" }, Size = 3, Lang = Lang.Zho });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(3));

            cities = Client.GetCities(new CityRequest { CountryCodes = new[] { "JP" }, Size = 10 });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(10));
            Assert.That(cities.Select(r => r.CountryCode).First(), Is.EqualTo("JP"));
            Assert.That(cities.Select(r => r.CountryCode).Distinct().Count(), Is.EqualTo(1));

            cities = Client.GetCities(new CityRequest { CountryCodes = new[] { "FR", "JP" }, Size = 10, Lang = Lang.Eng });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(10));
            Assert.That(cities.Select(r => r.CountryCode).Distinct().Count(), Is.AnyOf(1, 2));
        }

        [Test]
        public void CalculateTariffList()
        {
            var tariffs = Client.CalculateTariffList(new TariffRequest
            {
                DeliveryType = DeliveryType.Delivery,
                Lang = Lang.Eng,
                FromLocation = new Location { CityCode = 270 },
                ToLocation = new Location { CityCode = 44 },
                Packages = new[]
                {
                    new PackageSize
                    {
                        Weight = 4000,
                        Height = 10,
                        Width = 10,
                        Length = 10
                    }
                }
            });

            Assert.That(tariffs, Is.Not.Null);
            Assert.That(tariffs.TariffCodes, Is.Not.Null);
            Assert.That(tariffs.TariffCodes, Is.Not.Empty);
        }
    }
}