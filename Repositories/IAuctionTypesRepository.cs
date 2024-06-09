using AuctionTypesCMS.Entities;

namespace AuctionTypesCMS.Repositories
{
    public interface IAuctionTypesRepository
    {
        List<AuctionType> GetAll();
        void Add(AuctionType auctionType);
        void Update(AuctionType auctionType);  
        void Delete(int auctionTypeId);
    }
}
