using System.Text.Json.Serialization;

namespace App.Model
{
    public class GetActionCountRequest
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }
    }
}