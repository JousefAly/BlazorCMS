using AuctionTypesCMS.Entities;
using AuctionTypesCMS.Repositories;

namespace AuctionTypesCMS.Services
{
    public class AuctionTypesService : IAuctionTypesServices
    {
        private readonly IAuctionTypesRepository _auctionTypesRepository;

        public AuctionTypesService(IAuctionTypesRepository auctionTypesRepository)
        {
            _auctionTypesRepository = auctionTypesRepository;
        }
        public void Add(AuctionType auctionType)
        {
            auctionType.CreatedDate = DateTime.UtcNow;
            _auctionTypesRepository.Add(auctionType);
        }

        public void Delete(int auctionTypeId)
        {
          _auctionTypesRepository.Delete(auctionTypeId);  
        }

        public List<AuctionType> GetAll()
        {
           return _auctionTypesRepository.GetAll();
        }

        public void Update(AuctionType auctionType)
        {
            _auctionTypesRepository.Update(auctionType);
        }
    }
}
