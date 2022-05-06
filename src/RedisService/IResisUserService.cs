using App.Model;

interface IRedisUserService
{
    public User CreateUser(string userName, DateTime date);
    public User GetUser(string userName);
}