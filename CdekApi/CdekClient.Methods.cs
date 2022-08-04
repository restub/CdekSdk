using System.Collections.Generic;
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
        public RegionResponse[] GetRegions(RegionRequest request = null)
        {
            var parameters = new List<Parameter>();
            if (request != null)
            {
                if (string.IsNullOrEmpty(request.Lang))
                {
                    parameters.Add(new Parameter("lang", request.Lang, ParameterType.QueryString));
                }

                if (request.Size != null)
                {
                    parameters.Add(new Parameter("size", request.Size, ParameterType.QueryString));
                }

                if (request.Page != null)
                {
                    parameters.Add(new Parameter("page", request.Page, ParameterType.QueryString));
                }
            }

            return Get<RegionResponse[]>("location/regions", parameters.ToArray());
        }

        /// <summary>
        /// Gets the list of cities.
        /// EN: https://api-docs.cdek.ru/33829473.html
        /// RU: https://api-docs.cdek.ru/33829437.html
        /// </summary>
        public CityResponse[] GetCities(CityRequest request = null)
        {
            var parameters = new List<Parameter>();
            if (request != null)
            {
                if (string.IsNullOrEmpty(request.Lang))
                {
                    parameters.Add(new Parameter("lang", request.Lang, ParameterType.QueryString));
                }

                if (request.Size != null)
                {
                    parameters.Add(new Parameter("size", request.Size, ParameterType.QueryString));
                }

                if (request.Page != null)
                {
                    parameters.Add(new Parameter("page", request.Page, ParameterType.QueryString));
                }
            }

            return Get<CityResponse[]>("location/cities", parameters.ToArray());
        }
    }
}