using App.Model;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

class GetGreetingActivity: IActivity
{
    private const string _method = "GET";
    private const string _endpoint = "/greeting";

    public ActivityIdentifier GetActivityIdentifier()
    {
        return new ActivityIdentifier(_method, _endpoint);
    }

    public void PerformActivityWithContext(HttpListenerContext context)
    {
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        string requestBody = GetBodyFromRequest(request);
        GetGreetingRequest getGreetingRequest = JsonSerializer.Deserialize<GetGreetingRequest>(requestBody);

        GetGreetingRespone getGreetingResponse = new GetGreetingRespone()
        {
            Greeting = $"Hello, {getGreetingRequest.Name}!"
        };

        string responseString = JsonSerializer.Serialize(getGreetingResponse);
        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();
    }

    private string GetBodyFromRequest(HttpListenerRequest request)
    {
        Stream stream = request.InputStream;
        Encoding encoding = request.ContentEncoding;
        StreamReader reader = new StreamReader(stream, encoding);
        string body = reader.ReadToEnd();
        return body;
    }
}