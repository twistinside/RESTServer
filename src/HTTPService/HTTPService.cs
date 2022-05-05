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

            try
            {
                IActivity activity = _activityProvider.GetActivityFromContext(context);
                activity.PerformActivityWithContext(context);
            }
            catch
            {
                
            }
            
            listener.Stop();
        }
    }
}