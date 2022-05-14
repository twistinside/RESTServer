using App.Model;
using StackExchange.Redis;
using System.Text.Json;

namespace App.Redis
{
    class RedisService: IRedisActionService
    {
        private ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("localhost");
        
        public int AddAction(string action)
        {
            return AddActionCount(action, 1);
        }

        public int AddActionCount(string action, int count)
        {
            Console.WriteLine($"Incrementing count for {action}.");
            IDatabase db = _redis.GetDatabase();
            int redisCount = (int)db.StringGet(action);
            count += redisCount;
            db.StringSet(action, count);
            Console.WriteLine($"Count is now {count}.");
            return count;
        }

        public int GetActionCount(string action)
        {
            Console.WriteLine($"Getting count for {action}.");
            IDatabase db = _redis.GetDatabase();
            int count = (int)db.StringGet(action);
            Console.WriteLine($"Count is {count}.");
            return count;
        }
    }
}