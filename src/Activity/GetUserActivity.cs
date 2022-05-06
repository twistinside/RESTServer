using App.Model;
using System.Net;
using System.Text;
using System.Text.Json;

class GetUserActivity: IActivity
{
    private const string _method = "GET";
    private const string _endpoint = "/user";

    private IRedisUserService _redisService;

    public GetUserActivity(IRedisUserService redisService)
    {
        this._redisService = redisService;
    }

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

        User user = _redisService.GetUser(getUserRequest.UserName);

        GetUserResponse getUserResponse = new GetUserResponse()
        {
            UserName = user.UserName,
            UserSince = user.UserSince
        };

        string responseString = JsonSerializer.Serialize(getUserResponse);
        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();
    }
}