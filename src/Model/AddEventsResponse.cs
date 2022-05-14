using System.Text.Json.Serialization;

namespace App.Model
{
    public class AddEventsResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        override public bool Equals(object? obj)
        {
            var item = obj as AddEventsResponse;

            if (item == null)
            {
                return false;
            }

            return this.Count.Equals(item.Count);
        }

        override public int GetHashCode()
        {
            return this.Count.GetHashCode();
        }
    }
}