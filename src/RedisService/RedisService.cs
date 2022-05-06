using App.Model;
using StackExchange.Redis;
using System.Text.Json;

namespace App.Redis
{
    class RedisService: IRedisUserService
    {
        private ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("localhost");

        public User CreateUser(string userName, DateTime date)
        {
            User user = new User()
            {
                UserName = userName,
                UserSince = date
            };

            IDatabase db = _redis.GetDatabase();
            db.StringSet(userName, JsonSerializer.Serialize(user));

            return user;
        }

        public User GetUser(string userName)
        {
            IDatabase db = _redis.GetDatabase();
            string userString = db.StringGet(userName);
            return JsonSerializer.Deserialize<User>(userString);
        }
    }
}