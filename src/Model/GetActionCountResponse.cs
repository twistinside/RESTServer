using System.Text.Json.Serialization;

namespace App.Model
{
    public class GetActionCountRespone
    {
        [JsonPropertyName("action")]
        public string action { get; set; }
        [JsonPropertyName("count")]
        public int count { get; set; }
    }
}