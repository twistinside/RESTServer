class RESTServer
{

    static void Main(string[] args)
    {
        // Register activities with the activity factory
        ActivityProvider activityProvider = new ActivityProvider();
        activityProvider.RegisterActivity(new GetGreetingActivity());

        // Create the HTTPService and listen
        IHTTPService httpService = new HTTPService(activityProvider);
        while (true)
        {
            httpService.Listen();
        }
    }
}