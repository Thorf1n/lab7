

namespace Cache
{
    public class FunctionCache<TKey, TResult>
    {
        private readonly Dictionary<TKey, CacheItem<TResult>> cache = new Dictionary<TKey, CacheItem<TResult>>();
        private readonly Func<TKey, TResult> _function;

        public FunctionCache(Func<TKey, TResult> function)
        {
            _function = function;
        }

        public TResult GetResult(TKey key)
        {
            if (cache.TryGetValue(key, out CacheItem<TResult> cachedItem) && cachedItem.IsValid())
            {
                Console.WriteLine($"Cached Result for key {key}: {cachedItem.Result}");
                return cachedItem.Result;
            }

            TResult result = _function(key);
            CacheItem<TResult> newItem = new CacheItem<TResult>(result);
            cache[key] = newItem;
            Console.WriteLine($"Calculating result for key: {key}");
            Console.WriteLine($"Cached Result for key {key}: {result}");
            return result;
        }

        public void SetCacheValidityPeriod(TKey key, TimeSpan validityPeriod)
        {
            if (cache.TryGetValue(key, out CacheItem<TResult> cachedItem))
            {
                cachedItem.SetValidityPeriod(validityPeriod);
            }
        }

        private class CacheItem<T>
        {
            public T Result { get; }
            private DateTime ExpirationTime { get; set; }

            public CacheItem(T result)
            {
                Result = result;
                ExpirationTime = DateTime.UtcNow.AddHours(1); // Default validity period: 1 hour
            }

            public bool IsValid()
            {
                return DateTime.UtcNow < ExpirationTime;
            }

            public void SetValidityPeriod(TimeSpan validityPeriod)
            {
                ExpirationTime = DateTime.UtcNow.Add(validityPeriod);
            }
        }
    }
}
    

