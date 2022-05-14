using System.Text.Json.Serialization;

namespace App.Model
{
    public class UserEvent
    {
        [JsonPropertyName("app")]
        public string App { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("session_id")]
        public string SessionId { get; set; }
        [JsonPropertyName("local_time")]
        public string LocalTime { get; set; }
        [JsonPropertyName("action")]
        public string Action { get; set; }
        [JsonPropertyName("context")]
        public string Context { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}