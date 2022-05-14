using System.Text.Json.Serialization;

namespace App.Model
{
    public class GetActionCountRespone
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }

        override public bool Equals(object? obj)
        {
            var item = obj as GetActionCountRespone;

            if (item == null)
            {
                return false;
            }

            return this.Action.Equals(item.Action) &&
                this.Count.Equals(item.Count);
        }

        override public int GetHashCode()
        {
            return this.Action.GetHashCode() *
                this.Count.GetHashCode();
        }
    }
}