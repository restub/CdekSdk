# CDEK API

[![CDEK API Client v2.0](https://img.shields.io/badge/cdek%20api-v2.0-%2300B33C)](https://api-docs.cdek.ru/29923741.html)
[![Code quality](https://img.shields.io/codefactor/grade/github/restub/CdekSdk)](https://www.codefactor.io/repository/github/restub/CdekSdk)
[![GitHub Actions](https://img.shields.io/endpoint.svg?url=https%3A%2F%2Factions-badge.atrox.dev%2Fyallie%2FCdekSdk%2Fbadge&label=build&logo=none)](https://actions-badge.atrox.dev/yallie/CdekSdk/goto)
[![.NET Framework 4.62](https://img.shields.io/badge/.net-v4.62-yellow)](https://www.microsoft.com/ru-RU/download/details.aspx?id=53321)
[![NuGet](https://img.shields.io/nuget/v/CdekSdk.svg)](https://nuget.org/packages/CdekSdk)

# Getting started

* Install CdekSdk Nuget package: https://www.nuget.org/packages/CdekSdk
* Register on the [CDEK website](https://www.cdek.ru/) to get your username and password, or use `Credentials.TestCredentials`
* Create `CdekClient` using your credentials and connect to either endpoint:
  * `CdekClient.SandboxApiUrl` — for testing
  * `CdekClient.ProductionApiUrl` — for production code
* Set `CdekClient.Tracer` callback to `Console.WriteLine` or your favorite logger's `WriteLine` method. 
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
    Packages =
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
    Packages =
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

# Tracing

To enable tracing all http requests and responses, set the `Tracer` property:

```c#
client.Tracer = Console.WriteLine;
```

<details>
  <summary>A typical trace log looks like this:</summary>
    
```c
// GetAuthToken
-> POST https://api.edu.cdek.ru/v2/oauth/token?parameters
headers: {
  X-ApiMethodName = GetAuthToken
  Accept = application/json, text/json, text/x-json, text/javascript, application/xml, text/xml
  Content-type = application/json
}
body: null

<- OK 200 (OK) https://api.edu.cdek.ru/v2/oauth/token?parameters
timings: {
  started: 2022-08-31 15:30:57
  elapsed: 0:00:00.812
}
headers: {
  Transfer-Encoding = chunked
  Connection = keep-alive
  Keep-Alive = timeout=15
  Vary = Accept-Encoding
  Pragma = no-cache
  X-Content-Type-Options = nosniff
  X-XSS-Protection = 1; mode=block
  X-Frame-Options = DENY
  Content-Encoding = 
  Cache-Control = no-store
  Content-Type = application/json;charset=utf-8
  Date = Wed, 31 Aug 2022 12:30:59 GMT
  Server = QRATOR
}
body: {
  "access_token": "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY29wZSI6WyJvcmRlcjphbGwiLCJwYXltZW50OmFsbCJdLCJleHAiOjE2NjE5NTI2NTksImF1dGhvcml0aWVzIjpbInNoYXJkLWlkOnJ1LTAxIiwiY2xpZW50LWNpdHk60J3QvtCy0L7RgdC40LHQuNGA0YHQuiwg0J3QvtCy0L7RgdC40LHQuNGA0YHQutCw0Y8g0L7QsdC70LDRgdGC0YwiLCJmdWxsLW5hbWU60KLQtdGB0YLQuNGA0L7QstCw0L3QuNC1INCY0L3RgtC10LPRgNCw0YbQuNC4INCY0JwsINCe0JHQqdCV0KHQotCS0J4g0KEg0J7Qk9Cg0JDQndCY0KfQldCd0J3QntCZINCe0KLQktCV0KLQodCi0JLQldCd0J3QntCh0KLQrNCuIiwiYWNjb3VudC1sYW5nOnJ1cyIsImNvbnRyYWN0OtCY0Jwt0KDQpC3Qk9Cb0JMtMjIiLCJhY2NvdW50LXV1aWQ6ZTkyNWJkMGYtMDVhNi00YzU2LWI3MzctNGI5OWMxNGY2NjlhIiwiYXBpLXZlcnNpb246MS4xIiwiY2xpZW50LWlkLWVjNTplZDc1ZWNmNC0zMGVkLTQxNTMtYWZlOS1lYjgwYmI1MTJmMjIiLCJjbGllbnQtaWQtZWM0OjE0MzQ4MjMxIiwic29saWQtYWRkcmVzczpmYWxzZSIsImNvbnRyYWdlbnQtdXVpZDplZDc1ZWNmNC0zMGVkLTQxNTMtYWZlOS1lYjgwYmI1MTJmMjIiXSwianRpIjoiOGQ3MDc0MWYtODc3Ni00MTFjLTgwZjEtZjg3MGI2MDhiYzUyIiwiY2xpZW50X2lkIjoiRU1zY2Q2cjlKbkZpUTNiTG95akpZNmVNNzhKckpjZUkifQ.Ksoyu9zJHSc9AKqfytjwURwO3Eba03y0mC2LcN9cHTzKYJ-fSQzsjTk6z0qI4GeFgMHGrhEfrXPGMr19TwvsaTUKxfTObFnKhaN_xOfCDgZarI_Y5X3_rcGlBMxcbSRQKiKLuZ0c1ob6gTrFo4AuxiD5LyaJJJ4WCQRWkJJJu9zGuE_s2rRwpegcB6B2AqvGlfGrTDvaSgvJqWFAYNkFgGAjDYLvzdIrUD-C0Cad7p6eFvfML68Nh73Y4qityvge1PIZvYaQOAGzP_eeoFoDNxK4ygxqm64wem4umx0pYKZaacdYA6WV-ptfEayfd_Dxq00EGA-z8dYtyD6Y8yToig",
  "token_type": "bearer",
  "expires_in": 3599,
  "scope": "order:all payment:all",
  "jti": "8d70741f-8776-411c-80f1-f870b608bc52"
}

// CreateDeliveryOrder
-> POST https://api.edu.cdek.ru/v2/orders
headers: {
  X-ApiMethodName = CreateDeliveryOrder
  Authorization = Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY29wZSI6WyJvcmRlcjphbGwiLCJwYXltZW50OmFsbCJdLCJleHAiOjE2NjE5NTI2NTksImF1dGhvcml0aWVzIjpbInNoYXJkLWlkOnJ1LTAxIiwiY2xpZW50LWNpdHk60J3QvtCy0L7RgdC40LHQuNGA0YHQuiwg0J3QvtCy0L7RgdC40LHQuNGA0YHQutCw0Y8g0L7QsdC70LDRgdGC0YwiLCJmdWxsLW5hbWU60KLQtdGB0YLQuNGA0L7QstCw0L3QuNC1INCY0L3RgtC10LPRgNCw0YbQuNC4INCY0JwsINCe0JHQqdCV0KHQotCS0J4g0KEg0J7Qk9Cg0JDQndCY0KfQldCd0J3QntCZINCe0KLQktCV0KLQodCi0JLQldCd0J3QntCh0KLQrNCuIiwiYWNjb3VudC1sYW5nOnJ1cyIsImNvbnRyYWN0OtCY0Jwt0KDQpC3Qk9Cb0JMtMjIiLCJhY2NvdW50LXV1aWQ6ZTkyNWJkMGYtMDVhNi00YzU2LWI3MzctNGI5OWMxNGY2NjlhIiwiYXBpLXZlcnNpb246MS4xIiwiY2xpZW50LWlkLWVjNTplZDc1ZWNmNC0zMGVkLTQxNTMtYWZlOS1lYjgwYmI1MTJmMjIiLCJjbGllbnQtaWQtZWM0OjE0MzQ4MjMxIiwic29saWQtYWRkcmVzczpmYWxzZSIsImNvbnRyYWdlbnQtdXVpZDplZDc1ZWNmNC0zMGVkLTQxNTMtYWZlOS1lYjgwYmI1MTJmMjIiXSwianRpIjoiOGQ3MDc0MWYtODc3Ni00MTFjLTgwZjEtZjg3MGI2MDhiYzUyIiwiY2xpZW50X2lkIjoiRU1zY2Q2cjlKbkZpUTNiTG95akpZNmVNNzhKckpjZUkifQ.Ksoyu9zJHSc9AKqfytjwURwO3Eba03y0mC2LcN9cHTzKYJ-fSQzsjTk6z0qI4GeFgMHGrhEfrXPGMr19TwvsaTUKxfTObFnKhaN_xOfCDgZarI_Y5X3_rcGlBMxcbSRQKiKLuZ0c1ob6gTrFo4AuxiD5LyaJJJ4WCQRWkJJJu9zGuE_s2rRwpegcB6B2AqvGlfGrTDvaSgvJqWFAYNkFgGAjDYLvzdIrUD-C0Cad7p6eFvfML68Nh73Y4qityvge1PIZvYaQOAGzP_eeoFoDNxK4ygxqm64wem4umx0pYKZaacdYA6WV-ptfEayfd_Dxq00EGA-z8dYtyD6Y8yToig
  Accept = application/json, text/json, text/x-json, text/javascript, application/xml, text/xml
  Content-type = application/json
}
body: {
  "type": "2",
  "number": null,
  "tariff_code": 480,
  "comment": "Test order",
  "developer_key": null,
  "shipment_point": null,
  "delivery_point": null,
  "date_invoice": null,
  "shipper_name": null,
  "shipper_address": null,
  "delivery_recipient_cost": null,
  "delivery_recipient_cost_adv": null,
  "from_location": {
    "code": null,
    "fias_guid": null,
    "postal_code": null,
    "longitude": 37.678685,
    "latitude": 55.788576,
    "country_code": null,
    "region": null,
    "region_code": 0,
    "sub_region": null,
    "city": "Москва",
    "address": "Русаковская улица, 31"
  },
  "to_location": {
    "code": null,
    "fias_guid": null,
    "postal_code": null,
    "longitude": 37.682035,
    "latitude": 55.789011,
    "country_code": null,
    "region": null,
    "region_code": 0,
    "sub_region": null,
    "city": "Москва",
    "address": "Русаковская улица, 26к1"
  },
  "packages": [
    {
      "number": "1",
      "comment": "Test",
      "weight": 1000,
      "height": 10,
      "length": 10,
      "width": 10
    }
  ],
  "sender": {
    "company": "Burattino",
    "name": "Basilio",
    "email": "basilio@example.com",
    "passport_series": null,
    "passport_number": null,
    "passport_date_of_issue": null,
    "passport_organization": null,
    "passport_date_of_birth": null,
    "tin": null,
    "phones": [
      {
        "number": "+71234567890",
        "additional": null
      }
    ]
  },
  "recipient": {
    "company": "Burattino",
    "name": "Alice",
    "email": "alice@example.com",
    "passport_series": null,
    "passport_number": null,
    "passport_date_of_issue": null,
    "passport_organization": null,
    "passport_date_of_birth": null,
    "tin": null,
    "phones": [
      {
        "number": "+79876543210",
        "additional": null
      }
    ]
  },
  "services": null
}

<- OK 202 (Accepted) https://api.edu.cdek.ru/v2/orders
timings: {
  started: 2022-08-31 15:30:57
  elapsed: 0:00:01.141
}
headers: {
  Transfer-Encoding = chunked
  Connection = keep-alive
  Keep-Alive = timeout=15
  X-Content-Type-Options = nosniff
  X-XSS-Protection = 1; mode=block
  Pragma = no-cache
  X-Frame-Options = DENY
  Cache-Control = no-cache, no-store, max-age=0, must-revalidate
  Content-Type = application/json
  Date = Wed, 31 Aug 2022 12:30:59 GMT
  Expires = 0
  Location = http://atlas-nsk-edu-app-04.node.atlas-nsk.cdek.tech:8939/v2/orders/72753031-7310-4448-b6fa-bf474772be48
  Server = QRATOR
}
body: {
  "entity": {
    "uuid": "72753031-7310-4448-b6fa-bf474772be48"
  },
  "requests": [
    {
      "request_uuid": "538aed98-3c14-4e2c-9ac0-7443f95a7da3",
      "type": "CREATE",
      "date_time": "2022-08-31T19:30:53+0700",
      "state": "ACCEPTED"
    }
  ]
}
```
</details>

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
