using System.Net;

interface IActivity
{
    ActivityIdentifier GetActivityIdentifier();
    void PerformActivityWithContext(HttpListenerContext context);
}