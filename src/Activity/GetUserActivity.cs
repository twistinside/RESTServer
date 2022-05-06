using App.Model;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

class GetUserActivity: IActivity
{
    private const string _method = "GET";
    private const string _endpoint = "/user";

    public ActivityIdentifier GetActivityIdentifier()
    {
        return new ActivityIdentifier(_method, _endpoint);
    }

    public void PerformActivityWithContext(HttpListenerContext context)
    {
        Console.WriteLine("Executing get user activity.");
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        string requestBody = Utils.GetBodyFromRequest(request);
        GetUserRequest getUserRequest = JsonSerializer.Deserialize<GetUserRequest>(requestBody);

        GetUserResponse getUserResponse = new GetUserResponse()
        {
            AverageReviewScore = 4,
            NumberOfFilmsWatched = 24,
            UserName = getUserRequest.UserName,
            UserSince = DateTime.Now
        };

        string responseString = JsonSerializer.Serialize(getUserResponse);
        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();
    }
}