using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Office/pickup point.
    /// EN: https://api-docs.cdek.ru/36990336.html
    /// RU: https://api-docs.cdek.ru/36982648.html
    /// </summary>
    [DataContract]
    public class OfficeResponse
    {
        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "location")]
        public OfficeLocation Location { get; set; }

        [DataMember(Name = "address_comment")]
        public string AddressComment { get; set; }

        [DataMember(Name = "nearest_station")]
        public string NearestStation { get; set; }

        [DataMember(Name = "nearest_metro_station")]
        public string NearestMetroStation { get; set; }

        [DataMember(Name = "work_time")]
        public string WorkTime { get; set; }

        [DataMember(Name = "phones")]
        public List<Phone> Phones { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "note")]
        public string Note { get; set; }

        [DataMember(Name = "type")]
        public OfficeType OfficeType { get; set; }

        [DataMember(Name = "owner_сode")]
        public string OwnerСode { get; set; }

        [DataMember(Name = "take_only")]
        public bool TakeOnly { get; set; }

        [DataMember(Name = "is_dressing_room")]
        public bool IsDressingRoom { get; set; }

        [DataMember(Name = "have_cashless")]
        public bool HasCashless { get; set; }

        [DataMember(Name = "have_cash")]
        public bool HasCash { get; set; }

        [DataMember(Name = "allowed_cod")]
        public bool CodAllowed { get; set; }

        [DataMember(Name = "fulfillment")]
        public bool HasFulfillmentZone { get; set; }

        [DataMember(Name = "work_time_list")]
        public OfficeSchedule[] OfficeSchedule { get; set; }

        [DataMember(Name = "work_time_exceptions")]
        public OfficeScheduleException[] OfficeScheduleExceptions { get; set; }

        [DataMember(Name = "weight_min")]
        public decimal WeightMin { get; set; }

        [DataMember(Name = "weight_max")]
        public decimal WeightMax { get; set; }

        [DataMember(Name = "dimensions")]
        public CellDimensions[] CellDimensions { get; set; }
    }
}
