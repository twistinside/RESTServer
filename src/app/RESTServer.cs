class RESTServer
{

    static void Main(string[] args)
    {
        ActivityProvider activityProvider = new ActivityProvider();
        activityProvider.RegisterActivity(new GetGreetingActivity());

        IHTTPService httpService = new HTTPService(activityProvider);
        while (true)
        {
            httpService.Listen();
        }
    }
}