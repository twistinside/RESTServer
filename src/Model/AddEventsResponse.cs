using System.Text.Json.Serialization;

namespace App.Model
{
    public class AddEventsResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}