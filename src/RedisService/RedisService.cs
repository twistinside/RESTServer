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
            return AddActionWithCount(action, 1);
        }

        public int AddActionWithCount(string action, int count)
        {
            IDatabase db = _redis.GetDatabase();
            int redisCount = (int)db.StringGet(action);
            count += redisCount;
            db.StringSet(action, count);
            return count;
        }

        public int GetActionCount(string action)
        {
            IDatabase db = _redis.GetDatabase();
            int count = (int)db.StringGet(action);
            return count;
        }
    }
}
