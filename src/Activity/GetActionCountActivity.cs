using App.Model;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

class GetActionCountActivity: IActivity
{
    private const string _method = "GET";
    private const string _endpoint = "/events/";

    private IRedisActionService _redisService;
    private Stopwatch _stopwatch;

    public GetActionCountActivity(IRedisActionService redisService)
    {
        this._redisService = redisService;
        this._stopwatch = new Stopwatch();
    }

    public ActivityIdentifier GetActivityIdentifier()
    {
        return new ActivityIdentifier(_method, _endpoint);
    }

    public void PerformActivityWithContext(HttpListenerContext context)
    {
        Console.WriteLine("Executing get action count activity.");
        
        _stopwatch.Start();

        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        GetActionCountRequest getActionCountRequest = new GetActionCountRequest
        {
            Action = request.QueryString.Get("action")
        };

        int count = _redisService.GetActionCount(getActionCountRequest.Action);

        GetActionCountRespone getActionCountResponse = new GetActionCountRespone()
        {
            Action = getActionCountRequest.Action,
            Count = count
        };

        string responseString = JsonSerializer.Serialize(getActionCountResponse);
        response.StatusCode = 200;
        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();

        _stopwatch.Stop();
        Console.WriteLine("Get action count activity took {0} ms", _stopwatch.ElapsedMilliseconds);
    }
}