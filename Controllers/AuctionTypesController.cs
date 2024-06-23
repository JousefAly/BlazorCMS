using AuctionTypesCMS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuctionTypesCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionTypesController : ControllerBase
    {
        private readonly ICachedAuctionTypesRepository _cachedAuctionTypesRepository;

        public AuctionTypesController(ICachedAuctionTypesRepository cachedAuctionTypesRepository)
        {
            _cachedAuctionTypesRepository = cachedAuctionTypesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _cachedAuctionTypesRepository.GetById(id, default);
            return Ok(data);
        }
    }
}
