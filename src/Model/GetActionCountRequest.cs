using System.Text.Json.Serialization;

namespace App.Model
{
    public class GetActionCountRequest
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        override public bool Equals(object? obj)
        {
            var item = obj as GetActionCountRequest;

            if (item == null)
            {
                return false;
            }

            return this.Action.Equals(item.Action);
        }

        override public int GetHashCode()
        {
            return this.Action.GetHashCode();
        }
    }
}