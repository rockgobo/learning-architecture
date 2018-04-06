using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace lifbi.bookers.data.googleBooks
{
    public partial class BookQuery
    {
        [JsonProperty("totalItems")]
        public long TotalItems { get; set; }

        [JsonProperty("items")]
        public List<Book> Items { get; set; }
    }
    public partial class Book
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("volumeInfo")]
        public BookInfo BookInfo { get; set; }

        [JsonProperty("saleInfo")]
        public SaleInfo SaleInfo { get; set; }
    }
    public partial class SaleInfo
    {
        [JsonProperty("listPrice", NullValueHandling = NullValueHandling.Ignore)]
        public SaleInfoListPrice ListPrice { get; set; }

        [JsonProperty("retailPrice", NullValueHandling = NullValueHandling.Ignore)]
        public SaleInfoListPrice RetailPrice { get; set; }
    }
    public partial class SaleInfoListPrice
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    }
    public partial class BookInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("authors")]
        public List<string> Authors { get; set; }

        [JsonProperty("pageCount")]
        public long PageCount { get; set; }
    }
}
