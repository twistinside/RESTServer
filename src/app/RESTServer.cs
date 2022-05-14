using App.Redis;

class RESTServer
{

    static void Main(string[] args)
    {
        RedisService redisService = new RedisService();

        ActivityProvider activityProvider = new ActivityProvider();
        activityProvider.RegisterActivity(new AddEventsActivity(redisService));

        IHTTPService httpService = new HTTPService(activityProvider);
        while (true)
        {
            httpService.Listen();
        }
    }
}