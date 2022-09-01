using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents delivery order request status.
    /// EN: https://api-docs.cdek.ru/33828802.html
    /// RU: https://api-docs.cdek.ru/29923926.html
    /// </summary>
    [DataContract]
    public class RequestStatus
    {
        [DataMember(Name = "request_uuid")]
        public string RequestUuid { get; set; }

        [DataMember(Name = "type")]
        public RequestType Type { get; set; }

        [DataMember(Name = "state")]
        public RequestState State { get; set; }

        [DataMember(Name = "date_time")]
        public DateTime DateTime { get; set; }

        [DataMember(Name = "errors")]
        public List<Error> Errors { get; set; }

        [DataMember(Name = "warnings")]
        public List<Error> Warnings { get; set; }
    }
}
