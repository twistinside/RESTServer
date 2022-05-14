using System.Text.Json.Serialization;

namespace App.Model
{
    public class AddEventsRequest
    {
        [JsonPropertyName("user_events")]
        public List<UserEvent> UserEvents { get; set; }
    }
}