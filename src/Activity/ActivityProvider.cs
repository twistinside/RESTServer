using System.Net;

class ActivityProvider
{
    private Dictionary<ActivityIdentifier, IActivity> _activities = new Dictionary<ActivityIdentifier, IActivity>();

    public IActivity GetActivityFromContext(HttpListenerContext context)
    {
        string method = context.Request.HttpMethod;
        string path = context.Request.Url.AbsolutePath;

        ActivityIdentifier activityIdentifier = new ActivityIdentifier(method, path);

        try
        {
            return _activities[activityIdentifier];
        }
        catch (KeyNotFoundException e)
        {
            throw new HttpRequestException(e.Message);
        }
    }

    public void RegisterActivity(IActivity activity)
    {
        _activities.Add(activity.GetActivityIdentifier(), activity);
    }
}