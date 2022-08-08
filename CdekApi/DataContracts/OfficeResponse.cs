using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        public Location Location { get; set; } // TODO: change to OfficeLocation

        [DataMember(Name = "address_comment")]
        public string AddressComment { get; set; }

        [DataMember(Name = "nearest_station")]
        public string NearestStation { get; set; }

        [DataMember(Name = "nearest_metro_station")]
        public string NearestMetroStation { get; set; }

        [DataMember(Name = "work_time")]
        public string WorkTime { get; set; }

        //[DataMember(Name = "phones")]
        //public List<Phone> Phones { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "note")]
        public string Note { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "owner_сode")]
        public string OwnerСode { get; set; }

        [DataMember(Name = "take_only")]
        public bool TakeOnly { get; set; }

        [DataMember(Name = "is_dressing_room")]
        public bool IsDressingRoom { get; set; }

        [DataMember(Name = "have_cashless")]
        public bool HaveCashless { get; set; }

        [DataMember(Name = "have_cash")]
        public bool HaveCash { get; set; }

        [DataMember(Name = "allowed_cod")]
        public bool AllowedCod { get; set; }

        //[DataMember(Name = "work_time_list")]
        //public List<WorkTimeList> WorkTimeList { get; set; }

        //[DataMember(Name = "work_time_exceptions")]
        //public List<WorkTimeException> WorkTimeExceptions { get; set; }

        [DataMember(Name = "weight_min")]
        public double WeightMin { get; set; }

        [DataMember(Name = "weight_max")]
        public double WeightMax { get; set; }
    }
}
