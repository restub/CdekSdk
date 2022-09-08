using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CdekSdk.Toolbox;
using Newtonsoft.Json;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Delivery order.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public class DeliveryOrderRequest
    {
        [DataMember(Name = "type")]
        public DeliveryType? DeliveryType { get; set; } // default is DeliveryType.OnlineStore

        [DataMember(Name = "number")]
        public string OrderNumber { get; set; }

        [DataMember(Name = "tariff_code")]
        public int TariffCode { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "developer_key")]
        public string DeveloperKey { get; set; } // for module developers only

        [DataMember(Name = "shipment_point")]
        public string ShipmentPoint { get; set; } // either ShipmentPoint or FromLocation should be specified

        [DataMember(Name = "delivery_point")]
        public string DeliveryPoint { get; set; } // either DeliveryPoint or ToLocation should be specified

        [DataMember(Name = "date_invoice"), JsonConverter(typeof(DateOnlyConverter))]
        public DateTime? InvoiceDate { get; set; } // for international online orders only

        [DataMember(Name = "shipper_name")]
        public string ShipperName { get; set; } // for international online orders only

        [DataMember(Name = "shipper_address")]
        public string ShipperAddress { get; set; } // for international online orders only

        [DataMember(Name = "delivery_recipient_cost")]
        public DeliveryOrderPayment DeliveryRecipientCost { get; set; } // for online orders only

        [DataMember(Name = "delivery_recipient_cost_adv")]
        public List<DeliveryRecipientCostAdv> DeliveryRecipientCostAdv { get; set; }

        [DataMember(Name = "from_location")]
        public DeliveryOrderLocation FromLocation { get; set; }

        [DataMember(Name = "to_location")]
        public DeliveryOrderLocation ToLocation { get; set; }

        [DataMember(Name = "packages")]
        public List<Package> Packages { get; set; }

        [DataMember(Name = "sender")]
        public DeliveryOrderContactPerson Sender { get; set; } // not required for online e-shop orders

        [DataMember(Name = "recipient")]
        public DeliveryOrderContactPerson Recipient { get; set; }

        [DataMember(Name = "services")]
        public List<DeliveryOrderService> Services { get; set; } = new List<DeliveryOrderService>();
    }
}
