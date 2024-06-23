using AuctionTypesCMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionTypesCMS.Repositories
{
    public class AuctionTypesRepository : IAuctionTypesRepository
    {
        private readonly CMSContext _context;

        public AuctionTypesRepository(CMSContext context)
        {
            _context = context;
        }
        public void Add(AuctionType auctionType)
        {
            _context.Add(auctionType);
            _context.SaveChanges();
        }

        public void Delete(int auctionTypeId)
        {
            _context.AuctionTypes.Where(x => x.Id == auctionTypeId).ExecuteDelete();
        }

        public List<AuctionType> GetAll()
        {
            return _context.AuctionTypes.ToList();
        }

        public async Task<AuctionType> GetById(int id, CancellationToken cancellationToken = default)
        {
            return await _context.AuctionTypes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Update(AuctionType auctionType)
        {
            _context.Update(auctionType);
            _context.SaveChanges();
        }
    }
}
