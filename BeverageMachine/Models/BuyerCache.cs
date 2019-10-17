using System;
using System.Runtime.Caching;

namespace BeverageMachine.Models
{
    public class BuyerCache
    {
        public Buyer GetBuyer(string id)
        {
            MemoryCache memCache = MemoryCache.Default;
            return memCache.Get(id) as Buyer;
        }

        public bool Add(Buyer value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(value.Id, value, DateTime.Now.AddMinutes(20));
        }

        public void Update(Buyer value)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set(value.Id.ToString(), value, DateTime.Now.AddMinutes(20));
        }

        public void Delete(string id)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(id))
            {
                memoryCache.Remove(id);
            }
        }
    }
}