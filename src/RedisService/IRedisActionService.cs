interface IRedisActionService
{
    public int AddAction(string action);
    public int AddActionCount(string action, int count);
    public int GetActionCount(string action);
}