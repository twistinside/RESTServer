using App.Model;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

class CreateUserActivity: IActivity
{
    private const string _method = "POST";
    private const string _endpoint = "/user";

    public ActivityIdentifier GetActivityIdentifier()
    {
        return new ActivityIdentifier(_method, _endpoint);
    }

    public void PerformActivityWithContext(HttpListenerContext context)
    {
        Console.WriteLine("Executing create user activity.");
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        string requestBody = Utils.GetBodyFromRequest(request);
        CreateUserRequest createUserRequest = JsonSerializer.Deserialize<CreateUserRequest>(requestBody);

        CreateUserResponse createUserResponse = new CreateUserResponse()
        {
            UserName = createUserRequest.UserName,
            UserSince = DateTime.Now
        };

        string responseString = JsonSerializer.Serialize(createUserResponse);
        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();
    }
}