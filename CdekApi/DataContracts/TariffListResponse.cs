using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CdekApi.DataContracts
{
    /// <summary>
    /// Represents pre-order response, the list of available tariffs.
    /// EN: https://api-docs.cdek.ru/63347458.html
    /// RU: https://api-docs.cdek.ru/63345519.html
    /// </summary>
    [DataContract]
    public class TariffListResponse : IHasErrors
    {
        [DataMember(Name = "tariff_codes")]
        public TariffInfo[] TariffCodes { get; set; }

        [DataMember(Name = "errors")]
        public List<Error> Errors { get; set; }
    }
}
