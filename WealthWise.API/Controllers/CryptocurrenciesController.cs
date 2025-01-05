using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WealthWise.API.Data;
using WealthWise.API.Models;

namespace WealthWise.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptocurrenciesController : ControllerBase
    {
        private readonly ICryptocurrencyRepository _cryptocurrencyRepository;

        public CryptocurrenciesController(ICryptocurrencyRepository cryptocurrencyRepository)
        {
            _cryptocurrencyRepository = cryptocurrencyRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cryptocurrency>> GetCryptocurrency(int id)
        {
            var cryptocurrency = await _cryptocurrencyRepository.GetCryptocurrencyByIdAsync(id);
            if (cryptocurrency == null) return NotFound();
            return Ok(cryptocurrency);
        }

        [HttpPost]
        public async Task<ActionResult<Cryptocurrency>> CreateCryptocurrency(Cryptocurrency cryptocurrency)
        {
            await _cryptocurrencyRepository.AddCryptocurrencyAsync(cryptocurrency);
            return CreatedAtAction(nameof(GetCryptocurrency), new { id = cryptocurrency.CryptocurrencyId }, cryptocurrency);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCryptocurrency(int id, Cryptocurrency cryptocurrency)
        {
            if (id != cryptocurrency.CryptocurrencyId) return BadRequest();

            await _cryptocurrencyRepository.UpdateCryptocurrencyAsync(cryptocurrency);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCryptocurrency(int id)
        {
            await _cryptocurrencyRepository.DeleteCryptocurrencyAsync(id);
            return NoContent();
        }
    }
}
