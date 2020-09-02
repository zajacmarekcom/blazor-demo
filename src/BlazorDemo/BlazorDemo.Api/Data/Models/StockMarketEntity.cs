using BlazorDemo.Shared;

namespace BlazorDemo.Api.Data.Models
{
    public class StockMarketEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public string IdentifierCode { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        public Currency Currency { get; set; }
    }
}
