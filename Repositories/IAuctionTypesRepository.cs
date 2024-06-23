using AuctionTypesCMS.Entities;

namespace AuctionTypesCMS.Repositories
{
    public interface IAuctionTypesRepository
    {
        List<AuctionType> GetAll();
        Task<AuctionType> GetById(int id, CancellationToken cancellationToken);
        void Add(AuctionType auctionType);
        void Update(AuctionType auctionType);  
        void Delete(int auctionTypeId);
    }
}
