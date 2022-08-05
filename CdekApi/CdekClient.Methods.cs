using CdekApi.DataContracts;
using CdekApi.Toolbox;

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
        public RegionResponse[] GetRegions(RegionRequest getRegions = null) =>
            Get<RegionResponse[]>("location/regions", r => r.AddQueryString(getRegions));

        /// <summary>
        /// Gets the list of cities.
        /// EN: https://api-docs.cdek.ru/33829473.html
        /// RU: https://api-docs.cdek.ru/33829437.html
        /// </summary>
        public CityResponse[] GetCities(CityRequest getCities = null) =>
            Get<CityResponse[]>("location/cities", r => r.AddQueryString(getCities));

        /// <summary>
        /// Calculate the available tariffs for the given package delivery.
        /// EN: https://api-docs.cdek.ru/63347458.html
        /// RU: https://api-docs.cdek.ru/63345519.html
        /// </summary>
        /// <param name="request">Delivery options</param>
        public TariffResponse CalculateTariffList(TariffRequest request) =>
            Post<TariffResponse>("calculator/tarifflist", request);
    }
}