using System.Text.Json.Serialization;

namespace App.Model
{
    public class AddEventsRequest
    {
        [JsonPropertyName("user_events")]
        public List<UserEvent> UserEvents { get; set; }

        override public bool Equals(object? obj)
        {
            var item = obj as AddEventsRequest;

            if (item == null)
            {
                return false;
            }

            return this.UserEvents.Equals(item.UserEvents);
        }

        override public int GetHashCode()
        {
            return this.UserEvents.GetHashCode();
        }
    }
}