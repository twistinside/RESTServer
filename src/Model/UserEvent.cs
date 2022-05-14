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

        override public bool Equals(object? obj)
        {
            var item = obj as UserEvent;

            if (item == null)
            {
                return false;
            }

            return this.App.Equals(item.App) && 
                this.UserId.Equals(item.UserId) && 
                this.SessionId.Equals(item.SessionId) &&
                this.LocalTime.Equals(item.LocalTime) && 
                this.Action.Equals(item.Action) && 
                this.Context.Equals(item.Context) && 
                this.Value.Equals(item.Value); 

        }


        override public int GetHashCode()
        {
            return this.App.GetHashCode() *
                this.UserId.GetHashCode() *
                this.SessionId.GetHashCode() *
                this.LocalTime.GetHashCode() *
                this.Action.GetHashCode() *
                this.Context.GetHashCode() *
                this.Value.GetHashCode();
        }
    }
}