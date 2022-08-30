# CDEK API

[![CDEK API Client v2.0](https://img.shields.io/badge/cdek%20api-v2.0-%2300B33C)](https://api-docs.cdek.ru/29923741.html)
[![Code quality](https://img.shields.io/codefactor/grade/github/yallie/CdekSdk)](https://www.codefactor.io/repository/github/yallie/CdekSdk)
[![GitHub Actions](https://img.shields.io/endpoint.svg?url=https%3A%2F%2Factions-badge.atrox.dev%2Fyallie%2FCdekSdk%2Fbadge&label=build&logo=none)](https://actions-badge.atrox.dev/yallie/CdekSdk/goto)
[![.NET Framework 4.62](https://img.shields.io/badge/.net-v4.62-yellow)](https://www.microsoft.com/ru-RU/download/details.aspx?id=53321)
[![NuGet](https://img.shields.io/nuget/v/CdekSdk.svg)](https://nuget.org/packages/CdekSdk)

# Getting started

* Install CdekSdk Nuget package: https://www.nuget.org/packages/CdekSdk
* Register on the [CDEK website](https://www.cdek.ru/) to get your username and password, or use `Credentials.TestCredentials`
* Create `CdekClient` using your credentials and connect to either endpoint:
  * `CdekClient.SandboxApiUrl` — for testing
  * `CdekClient.ProductionApiUrl` — for production code
* Set `CdekClient.Tracer` callback to `Console.WriteLine` or your favorite `Logger.WriteLine` method. 
* Invoke `CdekClient` methods to calculate delivery tariffs, place orders, etc.
* Consult the original API documentation for the available methods:
  * [Russian documentation](https://api-docs.cdek.ru/29923741.html)
  * [English documentation](https://api-docs.cdek.ru/33828739.html)

## Sample code:

```c#
// use sandbox server and test developer account
var client = new CdekClient(CdekClient.SandboxApiUrl, Credentials.TestCredentials);
client.Tracer = Console.WriteLine;

// get Russian and Chinese cities available for CDEK delivery
var cities = client.GetCities(new CityRequest
{
    CountryCodes = new[] { "RU", "CN" }
});
```

## Calculating available tariffs

```c#
var tariffs = client.CalculateTariffList(new TariffListRequest
{
    DeliveryType = DeliveryType.Delivery,
    Date = DateTime.Today,
    Lang = Lang.Eng,
    FromLocation = new Location { CityCode = 270 }, // as returned by GetCities
    ToLocation = new Location { CityCode = 44 },
    Packages = new[]
    {
        new PackageSize
        {
            Weight = 4000, // grams
            Height = 10, // centimetres
            Width = 10,
            Length = 10
        }
    }
});
```

## Calculating delivery amount for the given tariff

```c#
var tariff = client.CalculateTariff(new TariffRequest
{
    TariffCode = 480, // as returned by CalculateTariffList
    DeliveryType = DeliveryType.Delivery,
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
```

## Placing a delivery order

```c#
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
```

# SDK versioning

The project uses [Nerdbank.GitVersioning](https://github.com/dotnet/Nerdbank.GitVersioning) tool to manage versions.  
Each library build can be traced back to the original git commit.

## Preparing and publishing a new release

1. Make sure that `nbgv` dotnet CLI tool is installed and is up to date
2. Run `nbgv prepare-release` to create a stable branch for the upcoming release, i.e. release/v1.0
3. Switch to the release branch: `git checkout release/v1.0`
4. Execute unit tests, update the README, etc. Commit and push your changes.
5. Run `dotnet pack -c Release` and check that it builds Nuget packages with the right version number.
6. Run `nbgv tag release/v1.0` to tag the last commit on the release branch with your current version number, i.e. v1.0.7.
7. Push tags as suggested by nbgv tool: `git push origin v1.0.7`
8. Go to github project page and create a release out of the last tag v1.0.7.
9. Verify that github workflow for publishing the nuget package has completed.
