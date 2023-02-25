using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CdekSdk.DataContracts;
using NUnit.Framework;

namespace CdekSdk.Tests
{
    [TestFixture]
    public class MethodTests
    {
        private TestClient Client { get; } = new TestClient();

        [Test, Ordered]
        public void BadInput()
        {
            var ex = Assert.Throws<CdekException>(() => Client.GetRegions(new RegionRequest { Page = 3 }));
            Assert.That(ex, Is.Not.Null);

            // reports something like: [size] is empty
            Assert.That(ex.Message, Contains.Substring("size"));
            Assert.That(ex.Message, Contains.Substring("empty"));
        }

        [Test, Ordered]
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

        [Test, Ordered]
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

        [Test, Ordered]
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
            Assert.That(cities.Length, Is.GreaterThanOrEqualTo(1));
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

        [Test, Ordered]
        public void GetOffices()
        {
            //foreach (var code in new[] { 125454, 600000, 187553, 354000, 309181, 220114, 187406, 790008 })
            //{
            //    var off = Client.GetOffices(new OfficeRequest { PostalCode = code });
            //    Assert.That(off, Is.Not.Null.And.Empty);
            //}

            var offices = Client.GetOffices(new OfficeRequest { PostalCode = 309181 }); // 125454
            Assert.That(offices, Is.Not.Null.And.Not.Empty);

            offices = Client.GetOffices(new OfficeRequest { CountryCode = "CN", Lang = Lang.Zho });
            Assert.That(offices, Is.Not.Null.And.Not.Empty);

            var city = Client.GetCities(new CityRequest { City = "Курган" });
            Assert.That(city, Is.Not.Null.And.Not.Empty);

            offices = Client.GetOffices(new OfficeRequest { CityCode = city.First(r => r.Region == "Курганская область").Code });
            Assert.That(offices, Is.Not.Null.And.Not.Empty);
        }

        [Test, Ordered]
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
                    Packages =
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

        [Test, Ordered]
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
                    Packages =
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
            }, Throws.TypeOf<CdekException>().With.Message.Contains("from_location"));

            // Possible error messages:
            // - Sender city is not specified
            // - No available tariffs for this direction and conditions
            // - По данному направлению при заданных условиях нет доступных тарифов
            Assert.That(() =>
            {
                Client.CalculateTariffList(new TariffListRequest
                {
                    DeliveryType = DeliveryType.Delivery,
                    Date = DateTime.Today,
                    Lang = Lang.Eng,
                    FromLocation = new Location { Address = "None" },
                    ToLocation = new Location { CityCode = 44 },
                    Packages =
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
            }, Throws.TypeOf<CdekException>().With
                .Message.Contains("Sender city not specified").Or
                .Message.Contains("No available tariffs for this direction and conditions").Or
                .Message.Contains("По данному направлению при заданных условиях нет доступных тарифов"));
        }

        [Test, Ordered]
        public void CalculateTariffSucceeds()
        {
            var tariff = Client.CalculateTariff(new TariffRequest
            {
                DeliveryType = DeliveryType.Delivery,
                TariffCode = 480,
                FromLocation = new Location { CityCode = 270 },
                ToLocation = new Location { CityCode = 44 },
                Packages =
                {
                    new PackageSize
                    {
                        Weight = 4000,
                        Height = 10,
                        Width = 10,
                        Length = 10
                    },
                },
                Services =
                {
                    new DeliveryOrderService { Code = ServiceType.BubbleWrap, Parameter = "1" },
                },
            });

            Assert.That(tariff, Is.Not.Null);
            Assert.That(tariff.Services, Is.Not.Null.And.Not.Empty);
            Assert.That(tariff.Services.Any(s => s.Code == ServiceType.BubbleWrap), Is.True);
        }

        [Test, Ordered]
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
                    Packages =
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
            }, Throws.TypeOf<CdekException>().With.Message.Contains("from_location"));

            // не указан город отправителя
            Assert.That(() =>
            {
                Client.CalculateTariff(new TariffRequest
                {
                    DeliveryType = DeliveryType.Delivery,
                    TariffCode = 480,
                    FromLocation = new Location { Address = "Null" },
                    ToLocation = new Location { CityCode = 44 },
                    Packages =
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
            }, Throws.TypeOf<CdekException>().With.Message.Contains("отправителя"));
        }

        [Test, Ordered]
        public void CreateDeliveryOrderFails()
        {
            // internal server error
            Assert.That(() => Client.CreateDeliveryOrder(null),
               Throws.TypeOf<CdekException>().With.Message.Contains("Internal"));

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
                    Company = "Burattino",
                    Name = "Basilio",
                    Email = "basilio@example.com",
                    Phones = new List<Phone>
                    {
                        new Phone { Number = "+71234567890" },
                    },
                },
                Recipient = new DeliveryOrderContactPerson
                {
                    Company = "Burattino",
                    Name = "Alice",
                    Email = "alice@example.com",
                    Phones = new List<Phone>
                    {
                        new Phone { Number = "+79876543210" },
                    },
                },
            }),
            Throws.TypeOf<CdekException>().With.Message.Contain("location.address").And.Message.Contain("empty"));
        }

        [Test, Ordered]
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
                    Company = "Burattino",
                    Name = "Basilio",
                    Email = "basilio@example.com",
                    Phones = new List<Phone>
                    {
                        new Phone { Number = "+71234567890" },
                    },
                },
                Recipient = new DeliveryOrderContactPerson
                {
                    Company = "Burattino",
                    Name = "Alice",
                    Email = "alice@example.com",
                    Phones = new List<Phone>
                    {
                        new Phone { Number = "+79876543210" },
                    },
                },
            });

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Entity, Is.Not.Null);
            Assert.That(DeliveryOrderUuid = response.Entity.Uuid, Is.Not.Null);
            Assert.That(response.Requests, Is.Not.Null.And.Not.Empty);
            Assert.That(response.Requests.First().RequestUuid, Is.Not.Null.And.Not.Empty);
        }

        private string DeliveryOrderUuid { get; set; } // set by CreateDeliveryOrderSucceeds test

        [Test, Ordered]
        public void GetDeliveryOrderSucceeds()
        {
            var retryCount = 3;
            for (var i = 0; i < retryCount; i++)
            {
                // make sure that delivery order transaction is committed
                if (DeliveryOrderUuid != null)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }

                try
                {
                    var details = Client.GetDeliveryOrder(DeliveryOrderUuid ?? "72753031-c5c0-4318-b02b-a0cefb7caee4");
                    Assert.That(details, Is.Not.Null);
                    Assert.That(details.Entity, Is.Not.Null);
                    Assert.That(details.Entity.Sender, Is.Not.Null);
                    Assert.That(details.Entity.Recipient, Is.Not.Null);
                    Assert.That(details.Entity.Sender.Name, Is.EqualTo("Basilio"));
                    Assert.That(details.Entity.Sender.Company, Is.EqualTo("Burattino"));
                    Assert.That(details.Entity.Recipient.Name, Is.EqualTo("Alice"));
                    Assert.That(details.Entity.Recipient.Company, Is.EqualTo("Burattino"));
                    TestContext.Progress.WriteLine("GetDeliveryOrder succeeded at attempt #" + i);
                    return;
                }
                catch (CdekException)
                {
                    // order not found, retry
                    continue;
                }
            }

            Assert.Fail("GetDeliveryOrder failed to return an order for " + retryCount + " times in a row.");
        }

        [Test, Ordered]
        public void GetDeliveryOrderFails()
        {
            Assert.That(() => Client.GetDeliveryOrder("A72932A5-E2DF-4165-9E3E-D79DB17EED81"), // random Guid
                Throws.TypeOf<CdekException>().With.Message.Contain("Entity").And.Message.Contain("not found"));
        }

        [Test, Ordered]
        public void DeleteDeliveryOrderFails()
        {
            Assert.That(() => Client.DeleteDeliveryOrder("A72932A5-E2DF-4165-9E3E-D79DB17EED81"), // random Guid
                Throws.TypeOf<CdekException>().With.Message.Contain("Entity").And.Message.Contain("not found"));
        }

        [Test, Ordered]
        public void DeleteDeliveryOrderSucceeds()
        {
            if (DeliveryOrderUuid != null)
            {
                TestContext.Progress.WriteLine("Testing whether delivery order exists: {0}", DeliveryOrderUuid);
                var order = Client.GetDeliveryOrder(DeliveryOrderUuid);
                Assert.That(order, Is.Not.Null);

                TestContext.Progress.WriteLine("Deleting DeliveryOrderUuid: {0}", DeliveryOrderUuid);
                var deleted = Client.DeleteDeliveryOrder(DeliveryOrderUuid);
                Assert.That(deleted, Is.Not.Null);
                Assert.That(deleted.Entity, Is.Not.Null);
                Assert.That(deleted.Entity.Uuid, Is.EqualTo(DeliveryOrderUuid));
                return;
            }

            TestContext.Progress.WriteLine("Warning: DeliveryOrderUuid is null. Deletion test is skipped.");
        }
    }
}