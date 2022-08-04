using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CdekApi.DataContracts
{
    [DataContract]
    public class ErrorResponse
    {
        [DataMember(Name = "errors")]
        public List<Error> Errors { get; set; }
    }
}
