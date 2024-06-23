using AuctionTypesCMS.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace AuctionTypesCMS.Repositories
{
    public class CachedAuctionTypesRepository : IAuctionTypesRepository
    {
        private readonly AuctionTypesRepository _decorated;
        private readonly IMemoryCache _memoryCache;

        public CachedAuctionTypesRepository(AuctionTypesRepository decorated, IMemoryCache memoryCache)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
        }


        public void Add(AuctionType auctionType)
        {
            _decorated.Add(auctionType);
        }
       
        public Task<AuctionType> GetById(int id, CancellationToken cancellationToken)
        {

            return _decorated.GetById(id, cancellationToken);
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
