using E_Commerce.Application.Dto.Cart;
using E_Commerce.Application.Services.Interfaces.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentMethodServices payment;

        public PaymentController(IPaymentMethodServices payment)
        {
            this.payment = payment;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPaymentMethod>>> GetPaymentMethods()
        {
            var method = await payment.GetPaymentMethods();
            if (!method.Any()) return NotFound();
            return Ok(method);
        }
    }
}
