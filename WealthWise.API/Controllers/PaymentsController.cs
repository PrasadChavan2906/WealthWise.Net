using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WealthWise.API.Data;
using WealthWise.API.Models;

namespace WealthWise.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PaymentsController : ControllerBase
	{
		private readonly IPaymentRepository _paymentRepository;

		public PaymentsController(IPaymentRepository paymentRepository)
		{
			_paymentRepository = paymentRepository;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Payment>> GetPayment(int id)
		{
			var payment = await _paymentRepository.GetPaymentByIdAsync(id);
			if (payment == null) return NotFound();
			return Ok(payment);
		}

		[HttpPost]
		public async Task<ActionResult<Payment>> CreatePayment(Payment payment)
		{
			await _paymentRepository.AddPaymentAsync(payment);
			return CreatedAtAction(nameof(GetPayment), new { id = payment.PaymentId }, payment);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdatePayment(int id, Payment payment)
		{
			if (id != payment.PaymentId) return BadRequest();

			await _paymentRepository.UpdatePaymentAsync(payment);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePayment(int id)
		{
			await _paymentRepository.DeletePaymentAsync(id);
			return NoContent();
		}
	}
}
