using App.Model;
using System.Net;
using System.Text;
using System.Text.Json;

class AddEventsActivity: IActivity
{
    private const string _method = "POST";
    private const string _endpoint = "/events";

    private IRedisActionService _redisService;

    public AddEventsActivity(IRedisActionService redisService)
    {
        this._redisService = redisService;
    }

    public ActivityIdentifier GetActivityIdentifier()
    {
        return new ActivityIdentifier(_method, _endpoint);
    }

    public void PerformActivityWithContext(HttpListenerContext context)
    {
        Console.WriteLine("Executing add events activity.");
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        string requestBody = Utils.GetBodyFromRequest(request);
        AddEventsRequest? addEventsRequest = JsonSerializer.Deserialize<AddEventsRequest>(requestBody);

        foreach (UserEvent userEvent in addEventsRequest.user_events)
        {
            _ = _redisService.AddAction(userEvent.action);
        }

        string responseString = $"Request successful.";
        response.StatusCode = 200;
        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();
    }
}