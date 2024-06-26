using AuctionTypesCMS.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace AuctionTypesCMS.Repositories
{
    public class CachedAuctionTypesRepository : ICachedAuctionTypesRepository, IAuctionTypesRepository
    {
        private readonly IAuctionTypesRepository _decorated;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public CachedAuctionTypesRepository(IAuctionTypesRepository decorated, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }


        public void Add(AuctionType auctionType)
        {
            _decorated.Add(auctionType);
        }

        public async Task<AuctionType> GetById(int id, CancellationToken cancellationToken)
        {
            string key = $"AuctionType-{id}";

            #region memory cashe
            //var data = await _memoryCache.GetOrCreate(key,
            //    entry =>
            //    {
            //        entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

            //        return _decorated.GetById(id, cancellationToken);
            //    })!;

            //return data;
            #endregion

            var value = await _distributedCache.GetStringAsync(key, cancellationToken);
            if (string.IsNullOrEmpty(value))
            {
                var auctionType = await _decorated.GetById(id, cancellationToken);
                if (auctionType == null)
                {
                    return auctionType;
                }

                await _distributedCache
                    .SetStringAsync(key, JsonSerializer.Serialize(auctionType), cancellationToken);
                return auctionType;
            }

            return JsonSerializer.Deserialize<AuctionType>(value)!;


        }

        public void Update(AuctionType auctionType)
        {
            _decorated.Update(auctionType);
        }
        public void Delete(int auctionTypeId)
        {
            throw new NotImplementedException();
        }

        public List<AuctionType> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
