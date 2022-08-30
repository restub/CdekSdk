using System;
using System.Collections.Generic;
using System.Linq;
using CdekSdk.DataContracts;
using NUnit.Framework;

namespace CdekSdk.Tests
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
        public void GetCityCode()
        {
            var cities = Client.GetCities(new CityRequest { City = "Ростов-на-Дону" });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(1));
            Assert.That(cities[0], Is.Not.Null);
            Assert.That(cities[0].Code, Is.EqualTo(438));

            cities = Client.GetCities(new CityRequest { City = "РОСТОВ-НА-ДОНУ" });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(1));
            Assert.That(cities[0], Is.Not.Null);
            Assert.That(cities[0].Code, Is.EqualTo(438));

            cities = Client.GetCities(new CityRequest { City = "Калининград" });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(1));
            Assert.That(cities[0], Is.Not.Null);
            Assert.That(cities[0].Code, Is.EqualTo(152));

            cities = Client.GetCities(new CityRequest { City = "МОСКВА" });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(1));
            Assert.That(cities[0], Is.Not.Null);
            Assert.That(cities[0].Code, Is.EqualTo(44));

            cities = Client.GetCities(new CityRequest { PostalCode = "115162" });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(1));
            Assert.That(cities[0], Is.Not.Null);
            Assert.That(cities[0].Code, Is.EqualTo(44));

            cities = Client.GetCities(new CityRequest { City = "Москва", PostalCode = "109125" });
            Assert.That(cities, Is.Not.Null);
            Assert.That(cities.Length, Is.EqualTo(1));
            Assert.That(cities[0], Is.Not.Null);
            Assert.That(cities[0].Code, Is.EqualTo(44));
        }

        [Test]
        public void GetOffices()
        {
            var offices = Client.GetOffices(new OfficeRequest { PostalCode = 125424 });
            Assert.That(offices, Is.Not.Null);
            Assert.That(offices, Is.Not.Empty);

            offices = Client.GetOffices(new OfficeRequest { CountryCode = "CN", Lang = Lang.Zho });
            Assert.That(offices, Is.Not.Null);
            Assert.That(offices, Is.Not.Empty);
        }

        [Test]
        public void CalculateTariffListSucceeds()
        {
            var retryCount = 3;

            for (var i = 0; i < retryCount; i++)
            {
                var tariffs = Client.CalculateTariffList(new TariffListRequest
                {
                    DeliveryType = DeliveryType.Delivery,
                    Date = DateTime.Today,
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

                // test server occasionally fails to return any items
                if (!tariffs.TariffCodes.Any())
                {
                    // retry if it's empty
                    continue;
                }

                Assert.That(tariffs.TariffCodes, Is.Not.Empty);
                return;
            }

            Assert.Fail("CalculateTariffList failed to return any tariffs " + retryCount + " times in a row. Failing...");
        }

        [Test]
        public void CalculateTariffListFails()
        {
            // [from_location] is empty
            Assert.That(() =>
            {
                Client.CalculateTariffList(new TariffListRequest
                {
                    DeliveryType = DeliveryType.Delivery,
                    Date = DateTime.Today,
                    Lang = Lang.Eng,
                    FromLocation = null,
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
            }, Throws.TypeOf<CdekApiException>().With.Message.Contains("from_location"));

            // Sender city is not specified
            Assert.That(() =>
            {
                Client.CalculateTariffList(new TariffListRequest
                {
                    DeliveryType = DeliveryType.Delivery,
                    Date = DateTime.Today,
                    Lang = Lang.Eng,
                    FromLocation = new Location { Address = "None" },
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
            }, Throws.TypeOf<CdekApiException>().With.Message.Contains("Sender"));
        }

        [Test]
        public void CalculateTariffSucceeds()
        {
            var tariff = Client.CalculateTariff(new TariffRequest
            {
                DeliveryType = DeliveryType.Delivery,
                TariffCode = 480,
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

            Assert.That(tariff, Is.Not.Null);
        }

        [Test]
        public void CalculateTariffFails()
        {
            // [from_location] is empty
            Assert.That(() =>
            {
                Client.CalculateTariff(new TariffRequest
                {
                    DeliveryType = DeliveryType.Delivery,
                    TariffCode = 480,
                    FromLocation = null,
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
            }, Throws.TypeOf<CdekApiException>().With.Message.Contains("from_location"));

            // не указан город отправителя
            Assert.That(() =>
            {
                Client.CalculateTariff(new TariffRequest
                {
                    DeliveryType = DeliveryType.Delivery,
                    TariffCode = 480,
                    FromLocation = new Location { Address = "Null" },
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
            }, Throws.TypeOf<CdekApiException>().With.Message.Contains("отправителя"));
        }

        [Test]
        public void CreateDeliveryOrderFails()
        {
            // internal server error
            Assert.That(() => Client.CreateDeliveryOrder(null), 
                Throws.TypeOf<CdekApiException>().With.Message.Contains("Internal"));

            // to_location.address is empty
            Assert.That(() => Client.CreateDeliveryOrder(new DeliveryOrderRequest
            {
                DeliveryType = DeliveryType.Delivery,
                Comment = "Test order",
                FromLocation = new DeliveryOrderLocation
                {
                    City = "Москва",
                    Latitude = 55.789046m,
                    Longitude = 37.679157m,
                },
                ToLocation = new DeliveryOrderLocation
                {
                    City = "Москва",
                    Latitude = 55.789011m,
                    Longitude = 37.682035m,
                },
                TariffCode = 480,
                Packages = new List<Package>()
                {
                    new Package
                    {
                        Number = "1",
                        Comments = "Test",
                        Weight = 1000,
                        Width = 10,
                        Height = 10,
                        Length = 10,
                    },
                },
                Sender = new DeliveryOrderContactPerson
                {
                    CompanyName = "Burattino",
                    ContactPersonName = "Basilio",
                    Email = "basilio@example.com",
                    Phones = new List<Phone>
                    {
                        new Phone { Number = "+71234567890" },
                    },
                },
                Recipient = new DeliveryOrderContactPerson
                {
                    CompanyName = "Burattino",
                    ContactPersonName = "Alice",
                    Email = "alice@example.com",
                    Phones = new List<Phone>
                    {
                        new Phone { Number = "+79876543210" },
                    },
                },
            }),
            Throws.TypeOf<CdekApiException>().With.Message.Contain("location.address").And.Message.Contain("empty"));
        }

        [Test]
        public void CreateDeliveryOrderSucceeds()
        {
            var response = Client.CreateDeliveryOrder(new DeliveryOrderRequest
            {
                DeliveryType = DeliveryType.Delivery,
                Comment = "Test order",
                FromLocation = new DeliveryOrderLocation
                {
                    City = "Москва",
                    Address = "Русаковская улица, 31",
                    Latitude = 55.788576m,
                    Longitude = 37.678685m,
                },
                ToLocation = new DeliveryOrderLocation
                {
                    City = "Москва",
                    Address = "Русаковская улица, 26к1",
                    Latitude = 55.789011m,
                    Longitude = 37.682035m,
                },
                TariffCode = 480,
                Packages = new List<Package>()
                {
                    new Package
                    {
                        Number = "1",
                        Comments = "Test",
                        Weight = 1000,
                        Width = 10,
                        Height = 10,
                        Length = 10,
                    },
                },
                Sender = new DeliveryOrderContactPerson
                {
                    CompanyName = "Burattino",
                    ContactPersonName = "Basilio",
                    Email = "basilio@example.com",
                    Phones = new List<Phone>
                    {
                        new Phone { Number = "+71234567890" },
                    },
                },
                Recipient = new DeliveryOrderContactPerson
                {
                    CompanyName = "Burattino",
                    ContactPersonName = "Alice",
                    Email = "alice@example.com",
                    Phones = new List<Phone>
                    {
                        new Phone { Number = "+79876543210" },
                    },
                },
            });

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Requests, Is.Not.Null.Or.Empty);
            Assert.That(response.Requests.First().RequestUuid, Is.Not.Null.Or.Empty);
        }
    }
}