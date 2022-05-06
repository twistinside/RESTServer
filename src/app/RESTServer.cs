class RESTServer
{

    static void Main(string[] args)
    {
        ActivityProvider activityProvider = new ActivityProvider();
        activityProvider.RegisterActivity(new CreateUserActivity());
        activityProvider.RegisterActivity(new GetUserActivity());

        IHTTPService httpService = new HTTPService(activityProvider);
        while (true)
        {
            httpService.Listen();
        }
    }
}