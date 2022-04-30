using System.Net;

class GetGreetingActivity: IActivity
{
    private string _name;

    public GetGreetingActivity(string name)
    {
        this._name = name;
    }
    public void PerformActivityWithResponse(HttpListenerResponse response)
    {
        string responseString = $"<HTML><BODY> Hello, {_name}!</BODY></HTML>";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        System.IO.Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();
    }
}