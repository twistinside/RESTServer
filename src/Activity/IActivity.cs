using System.Net;

interface IActivity
{
    ActivityIdentifier GetActivityIdentifier();
    void PerformActivityWithResponse(HttpListenerResponse response);
}