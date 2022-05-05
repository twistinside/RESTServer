class ActivityIdentifier
{
    public string verb;
    public string endpoint;

    public ActivityIdentifier(string verb, string endpoint)
    {
        this.verb = verb;
        this.endpoint = endpoint;
    }
}