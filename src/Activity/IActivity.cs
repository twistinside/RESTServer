using System.Net;

interface IActivity
{
    void PerformActivityWithResponse(HttpListenerResponse response);
}