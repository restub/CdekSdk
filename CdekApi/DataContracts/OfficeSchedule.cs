using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Represents the office schedule.
    /// EN: https://api-docs.cdek.ru/36990336.html
    /// RU: https://api-docs.cdek.ru/36982648.html
    /// </summary>
    [DataContract]
    public class OfficeSchedule
    {
        [DataMember(Name = "day")]
        public int Day { get; set; }

        [DataMember(Name = "time")]
        public string Time { get; set; }
    }
}
