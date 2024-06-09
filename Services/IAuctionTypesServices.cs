using AuctionTypesCMS.Entities;

namespace AuctionTypesCMS.Services
{
    public interface IAuctionTypesServices
    {
        List<AuctionType> GetAll();
        void Add(AuctionType auctionType);
        void Update(AuctionType auctionType);
        void Delete(int auctionTypeId);
    }
}
