class ActivityIdentifier
{
    public string method;
    public string endpoint;

    public ActivityIdentifier(string method, string endpoint)
    {
        this.method = method;
        this.endpoint = endpoint;
    }

    override public string ToString()
    {
        return $"Activity identifier:\n  method: {method}\n  endpoint: {endpoint}";
    }

    override public bool Equals(object? obj)
    {
        var item = obj as ActivityIdentifier;

        if (item == null)
        {
            return false;
        }

        return this.method.Equals(item.method) && this.endpoint.Equals(item.endpoint);
    }

    override public int GetHashCode()
    {
        return method.GetHashCode() * endpoint.GetHashCode();
    }
}