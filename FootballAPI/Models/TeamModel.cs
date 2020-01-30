using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FootballAPI.Models
{
    // This is model representing the Team Record
    public class TeamModel
    {
        // This identifies the team
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("img")]
        public string Img { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("modifiedAt")]
        public string ModifiedAt { get; set; }
    }
}
