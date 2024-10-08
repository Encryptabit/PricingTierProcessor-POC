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
        public WorkOSData Data { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }

    public class WorkOSData
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("state")]
        public string? State { get; set; }

        [JsonProperty("object")]
        public string? Object { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("domains")]
        public string[] Domains { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("external_key")]
        public string? ExternalKey { get; set; }

        [JsonProperty("connection_type")]
        public string? ConnectionType { get; set; }

        [JsonProperty("organization_id")]
        public string? OrganizationId { get; set; }
    }
}
