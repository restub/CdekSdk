﻿using System.Runtime.Serialization;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Represents the office phone.
    /// EN: https://api-docs.cdek.ru/36990336.html
    /// RU: https://api-docs.cdek.ru/36982648.html
    /// </summary>
    [DataContract]
    public class Phone
    {
        [DataMember(Name = "number")]
        public string Number { get; set; }

        [DataMember(Name = "additional")]
        public string Additional { get; set; }
    }
}