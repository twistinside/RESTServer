using System.Net;

class ActivityProvider
{
    private Dictionary<ActivityIdentifier, IActivity> _activities = new Dictionary<ActivityIdentifier, IActivity>();

    public IActivity GetActivityFromRequest(HttpListenerRequest request)
    {
        return new GetGreetingActivity();
    }

    public void RegisterActivity(IActivity activity)
    {
        _activities.Add(activity.GetActivityIdentifier(), activity);
    }
}