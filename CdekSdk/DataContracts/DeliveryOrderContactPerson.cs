using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CdekSdk.Toolbox;
using Newtonsoft.Json;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents CDEK order sender or receiver contact person.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public class DeliveryOrderContactPerson
    {
        [DataMember(Name = "name")]
        public string Name { get; set; } // not required for online e-shop orders

        [DataMember(Name = "company")]
        public string Company { get; set; } // not required for online e-shop orders

        [DataMember(Name = "email")]
        public string Email { get; set; } // not required for online e-shop orders

        [DataMember(Name = "passport_series")]
        public string PassportSeries { get; set; } // optional

        [DataMember(Name = "passport_number")]
        public string PassportNumber { get; set; } // optional

        [DataMember(Name = "passport_date_of_issue"), JsonConverter(typeof(DateOnlyConverter))]
        public DateTime? PassportDate { get; set; } // optional

        [DataMember(Name = "passport_organization")]
        public string PassportOrganization { get; set; } // optional

        [DataMember(Name = "passport_date_of_birth"), JsonConverter(typeof(DateOnlyConverter))]
        public DateTime? PassportBirthDate { get; set; } // optional

        [DataMember(Name = "tin")]
        public string Tin { get; set; } // optional INN, Taxpayer Identification Number

        [DataMember(Name = "phones")]
        public List<Phone> Phones { get; set; } // not required for online e-shop orders
    }
}
