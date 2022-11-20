using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Restub.DataContracts;

namespace CdekSdk.DataContracts
{
    /// <summary>
    /// Represents error messages.
    /// </summary>
    [DataContract]
    public class CdekErrorResponse : IHasErrors
    {
        [DataMember(Name = "errors")]
        public List<Error> Errors { get; set; }

        public string GetErrorMessage() => CdekClient.GetErrorMessage(Errors);

        public bool HasErrors() => Errors != null && Errors.Any();

    }
}
