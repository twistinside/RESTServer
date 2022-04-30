class RESTServer
{

    static void Main(string[] args)
    {
        IHTTPService httpService = new HTTPService();
        while (true)
        {
            httpService.Listen();
        }
    }
}