using System.Net;
using System.Text;

class Utils
{
    public static string GetBodyFromRequest(HttpListenerRequest request)
    {
        Stream stream = request.InputStream;
        Encoding encoding = request.ContentEncoding;
        StreamReader reader = new StreamReader(stream, encoding);
        string body = reader.ReadToEnd();
        return body;
    }
}