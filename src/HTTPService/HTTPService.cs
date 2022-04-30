using System.Net;

class HTTPService: IHTTPService
{
    string responseString = "<HTML><BODY> Hello, World!</BODY></HTML>";

    public void Listen()
    {
        string prefix = "http://+:8080/";

        using (var listener = new HttpListener())
        {
            listener.Prefixes.Add(prefix);
            listener.Start();
            Console.WriteLine("Awaiting HTTP request on port 8080...");

            // HTTPListener blocks while awaiting context
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer,0,buffer.Length);
            output.Close();
            listener.Stop();
        }
    }
}