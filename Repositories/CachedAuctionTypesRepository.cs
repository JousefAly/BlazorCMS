using AuctionTypesCMS.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace AuctionTypesCMS.Repositories
{
    public class CachedAuctionTypesRepository : ICachedAuctionTypesRepository, IAuctionTypesRepository
    {
        private readonly IAuctionTypesRepository _decorated;
        private readonly IMemoryCache _memoryCache;

        public CachedAuctionTypesRepository(IAuctionTypesRepository decorated, IMemoryCache memoryCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }


        public void Add(AuctionType auctionType)
        {
            _decorated.Add(auctionType);
        }

        public async Task<AuctionType> GetById(int id, CancellationToken cancellationToken)
        {
            string key = $"AuctionType-{id}";

            var data = await _memoryCache.GetOrCreate(key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                    return _decorated.GetById(id, cancellationToken);
                })!;

            return data;
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
