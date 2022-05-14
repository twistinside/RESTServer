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

            // Once context is acquired, get the appropriate activity and do the work
            try
            {
                IActivity activity = _activityProvider.GetActivityFromContext(context);
                activity.PerformActivityWithContext(context);
            }
            catch
            {
                Console.WriteLine("Request failed, closing listener.");
            }

            listener.Stop();
        }
    }
}