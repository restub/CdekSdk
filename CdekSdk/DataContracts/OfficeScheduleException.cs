using System;
using System.Runtime.Serialization;
using CdekSdk.Toolbox;
using Newtonsoft.Json;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents the office schedule.
    /// EN: https://api-docs.cdek.ru/36990336.html
    /// RU: https://api-docs.cdek.ru/36982648.html
    /// </summary>
    [DataContract]
    public class OfficeScheduleException
    {
        [DataMember(Name = "date"), JsonConverter(typeof(DateOnlyConverter))]
        public DateTime Date { get; set; } // date with no time specified

        [DataMember(Name = "time")]
        public string Time { get; set; }

        [DataMember(Name = "is_working")]
        public bool IsWorking { get; set; }
    }
}
