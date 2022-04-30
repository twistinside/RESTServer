using System.Net;

class ActivityFactory
{
    public static IActivity GetActivityFromRequest(HttpListenerRequest request)
    {
        return new GetGreetingActivity("Bruno");
    }
}