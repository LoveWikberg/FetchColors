using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fetch_Colors.Models
{
    public class ColorApiModel
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("data")]
        public IEnumerable<ColorModel> Colors { get; set; }
    }
}
