using AuctionTypesCMS.Entities;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;

namespace AuctionTypesCMS.Repositories
{
   
    public class CachedAuctionTypesRepository : ICachedAuctionTypesRepository, IAuctionTypesRepository
    {
        private readonly IAuctionTypesRepository _decorated;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;

        public CachedAuctionTypesRepository(IAuctionTypesRepository decorated,
            IMemoryCache memoryCache,
            IMapper mapper)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }


        public void Add(AuctionType auctionType)
        {
            _decorated.Add(auctionType);
        }

        public async Task<AuctionType> GetById(int id, CancellationToken cancellationToken)
        {
          
            try
            {               

                var person = new PersonDTO($"{id}");
                var personMapped = _mapper.Map<Person>(person);
                var personAgain = _mapper.Map<PersonDTO>(personMapped);
            }
            catch (Exception ex)
            {

                throw;
            }

           return new AuctionType { Id = id };
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
