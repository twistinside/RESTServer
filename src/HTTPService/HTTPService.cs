using System.Net;

class HTTPService: IHTTPService
{
    private ActivityProvider _activityProvider;

    public HTTPService(ActivityProvider activityProvider)
    {
        this._activityProvider = activityProvider;
    }

    public void Listen()
    {
        // This prefix listens to all requests on port 8080
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

            try
            {
                IActivity activity = _activityProvider.GetActivityFromRequest(request);
                activity.PerformActivityWithResponse(response);
            }
            catch
            {
                
            }
            
            listener.Stop();
        }
    }
}