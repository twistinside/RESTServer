using App.Model;
using System.Net;
using System.Text;
using System.Text.Json;

class GetActionCountActivity: IActivity
{
    private const string _method = "GET";
    private const string _endpoint = "/events/";

    private IRedisActionService _redisService;

    public GetActionCountActivity(IRedisActionService redisService)
    {
        this._redisService = redisService;
    }

    public ActivityIdentifier GetActivityIdentifier()
    {
        return new ActivityIdentifier(_method, _endpoint);
    }

    public void PerformActivityWithContext(HttpListenerContext context)
    {
        Console.WriteLine("Executing get action count activity.");
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        GetActionCountRequest getActionCountRequest = new GetActionCountRequest
        {
            Action = request.QueryString.Get("action")
        };

        int count = _redisService.GetActionCount(getActionCountRequest.Action);

        GetActionCountRespone getActionCountResponse = new GetActionCountRespone()
        {
            action = getActionCountRequest.Action,
            count = count
        };

        string responseString = JsonSerializer.Serialize(getActionCountResponse);
        response.StatusCode = 200;
        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();
    }
}