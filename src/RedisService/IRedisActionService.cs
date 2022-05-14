interface IRedisActionService
{
    public int AddAction(string action);
    public int AddActionWithCount(string action, int count);
    public int GetActionCount(string action);
}