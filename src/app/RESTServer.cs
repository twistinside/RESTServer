class RESTServer
{

    static void Main(string[] args)
    {
        IHTTPService httpService = new HTTPService();
        httpService.Listen();
    }
}