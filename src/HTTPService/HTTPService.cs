using System.Net;

class HTTPService: IHTTPService
{

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

            IActivity activity = ActivityFactory.GetActivityFromRequest(request);
            activity.PerformActivityWithResponse(response);

            listener.Stop();
        }
    }
}