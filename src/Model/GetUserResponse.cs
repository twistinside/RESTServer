namespace App.Model
{
    public class GetUserResponse
    {
        public int AverageReviewScore { get; set; }
        public int NumberOfFilmsWatched { get; set; }
        public string UserName { get; set; }
        public DateTime UserSince { get; set; }
    }
}