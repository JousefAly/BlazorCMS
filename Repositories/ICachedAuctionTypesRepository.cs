using AuctionTypesCMS.Entities;

namespace AuctionTypesCMS.Repositories
{
    public interface ICachedAuctionTypesRepository
    {
        Task<AuctionType> GetById(int id, CancellationToken cancellationToken);
    }
}
