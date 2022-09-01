using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CdekSdk.Toolbox;
using Newtonsoft.Json;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Delivery order entity.
    /// EN: https://api-docs.cdek.ru/33828849.html
    /// RU: https://api-docs.cdek.ru/29923975.html
    /// </summary>
    [DataContract]
    public class DeliveryOrderEntity : Entity
    {
        [DataMember(Name = "type")]
        public int Type { get; set; }

        [DataMember(Name = "is_return")]
        public bool IsReturn { get; set; }

        [DataMember(Name = "is_reverse")]
        public bool IsReverse { get; set; }

        [DataMember(Name = "cdek_number")]
        public string CdekNumber { get; set; }

        [DataMember(Name = "number")]
        public string Number { get; set; }

        [DataMember(Name = "delivery_mode")]
        public DeliveryMode DeliveryMode { get; set; }

        [DataMember(Name = "tariff_code")]
        public int TariffCode { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "delivery_recipient_cost")]
        public DeliveryOrderPayment DeliveryRecipientCost { get; set; }

        [DataMember(Name = "delivery_recipient_cost_adv")]
        public List<DeliveryRecipientCostAdv> DeliveryRecipientCostAdv { get; set; }

        [DataMember(Name = "sender")]
        public DeliveryOrderContactPerson Sender { get; set; }

        //[DataMember(Name = "seller")]
        //public Seller Seller { get; set; }

        [DataMember(Name = "recipient")]
        public DeliveryOrderContactPerson Recipient { get; set; }

        [DataMember(Name = "from_location")]
        public DeliveryOrderLocation FromLocation { get; set; }

        [DataMember(Name = "to_location")]
        public DeliveryOrderLocation ToLocation { get; set; }

        [DataMember(Name = "services")]
        public List<DeliveryOrderService> Services { get; set; }

        [DataMember(Name = "packages")]
        public List<Package> Packages { get; set; }

        [DataMember(Name = "delivery_problem")]
        public List<object> DeliveryProblem { get; set; }

        //[DataMember(Name = "statuses")]
        //public List<Status> Statuses { get; set; }

        [DataMember(Name = "delivery_date"), JsonConverter(typeof(DateOnlyConverter))]
        public DateTime DeliveryDate { get; set; }

        //[DataMember(Name = "delivery_detail")]
        //public DeliveryDetail DeliveryDetail { get; set; }
    }
}
