using CdekApi.DataContracts;
using RestSharp;

namespace CdekApi
{
    /// <remarks>
    /// CDEK API Client, methods.
    /// </remarks>
    public partial class CdekClient
    {
        /// <summary>
        /// Gets the list of regions.
        /// EN: https://api-docs.cdek.ru/33829453.html
        /// RU: https://api-docs.cdek.ru/33829418.html
        /// </summary>
        public Region[] GetRegions()
        {
            var regions = Get<Region[]>("location/regions");

            return regions;
        }
    }
}