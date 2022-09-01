using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents a package to be delivered.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public class Package : PackageSize
    {
        [DataMember(Name = "number")]
        public string Number { get; set; } // unique number of the package within the order, like order number in client's system

        [DataMember(Name = "comment")]
        public string Comments { get; set; } // required for delivery type of orders

        [DataMember(Name = "items")]
        public List<PackageItem> Items { get; set; }
    }
}
