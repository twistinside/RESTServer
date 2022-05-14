using App.Redis;

class RESTServer
{

    static void Main(string[] args)
    {
        RedisService redisService = new RedisService();

        ActivityProvider activityProvider = new ActivityProvider();
        activityProvider.RegisterActivity(new AddEventsActivity(redisService));
        activityProvider.RegisterActivity(new GetActionCountActivity(redisService));

        IHTTPService httpService = new HTTPService(activityProvider);
        while (true)
        {
            httpService.Listen();
        }
    }
}