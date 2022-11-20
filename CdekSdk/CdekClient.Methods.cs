using CdekSdk.DataContracts;
using Restub.Toolbox;

namespace CdekSdk
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
        /// Gets the list of offices.
        /// EN: https://api-docs.cdek.ru/36990336.html
        /// RU: https://api-docs.cdek.ru/36982648.html
        /// </summary>
        public OfficeResponse[] GetOffices(OfficeRequest getOffices = null) =>
            Get<OfficeResponse[]>("deliverypoints", r => r.AddQueryString(getOffices));

        /// <summary>
        /// Calculate the available tariffs for the given package delivery.
        /// EN: https://api-docs.cdek.ru/63347458.html
        /// RU: https://api-docs.cdek.ru/63345519.html
        /// </summary>
        /// <param name="request">Delivery options</param>
        public TariffListResponse CalculateTariffList(TariffListRequest request) =>
            Post<TariffListResponse>("calculator/tarifflist", request);

        /// <summary>
        /// Calculate the selected tariff for the given package delivery.
        /// EN: https://api-docs.cdek.ru/63347397.html
        /// RU: https://api-docs.cdek.ru/63345430.html
        /// </summary>
        /// <param name="request">Delivery options</param>
        public TariffResponse CalculateTariff(TariffRequest request) =>
            Post<TariffResponse>("calculator/tariff", request);

        /// <summary>
        /// Create delivery order.
        /// EN: https://api-docs.cdek.ru/33828802.html
        /// RU: https://api-docs.cdek.ru/29923926.html
        /// </summary>
        public DeliveryOrderResponse CreateDeliveryOrder(DeliveryOrderRequest request) =>
            Post<DeliveryOrderResponse>("orders", request);

        /// <summary>
        /// Get delivery order information.
        /// EN: https://api-docs.cdek.ru/33828849.html
        /// RU: https://api-docs.cdek.ru/29923975.html
        /// </summary>
        public DeliveryOrderDetails GetDeliveryOrder(string uuid) =>
            Get<DeliveryOrderDetails>("orders/{uuid}", r => r.AddUrlSegment("uuid", uuid));

        /// <summary>
        /// Delete delivery order.
        /// EN: https://api-docs.cdek.ru/33828855.html
        /// RU: https://api-docs.cdek.ru/29924487.html
        /// </summary>
        public DeliveryOrderResponse DeleteDeliveryOrder(string uuid) =>
            Delete<DeliveryOrderResponse>("orders/{uuid}", null, r => r.AddUrlSegment("uuid", uuid));
    }
}