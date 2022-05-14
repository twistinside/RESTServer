namespace App.Model
{
    public class UserEvent
    {
        public string app { get; set; }
        public string user_id { get; set; }
        public string session_id { get; set; }
        public string local_time { get; set; }
        public string action { get; set; }
        public string context { get; set; }
        public string value { get; set; }
    }
}