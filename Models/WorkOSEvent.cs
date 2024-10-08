using Newtonsoft.Json;
using System;


namespace PricingTierProcessor_POC.Models
{
    public class WorkOSEvent
    {
        [JsonProperty("event")]
        public string? Event { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("data")]
        public dynamic? Data { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
