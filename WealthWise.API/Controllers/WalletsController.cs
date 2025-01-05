using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WealthWise.API.Data;
using WealthWise.API.Models;

namespace WealthWise.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletRepository _walletRepository;

        public WalletsController(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Wallet>> GetWallet(int id)
        {
            var wallet = await _walletRepository.GetWalletByIdAsync(id);
            if (wallet == null) return NotFound();
            return Ok(wallet);
        }

        [HttpPost]
        public async Task<ActionResult<Wallet>> CreateWallet(Wallet wallet)
        {
            await _walletRepository.AddWalletAsync(wallet);
            return CreatedAtAction(nameof(GetWallet), new { id = wallet.WalletId }, wallet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWallet(int id, Wallet wallet)
        {
            if (id != wallet.WalletId) return BadRequest();

            await _walletRepository.UpdateWalletAsync(wallet);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWallet(int id)
        {
            await _walletRepository.DeleteWalletAsync(id);
            return NoContent();
        }
    }
}
