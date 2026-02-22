using E_Commerce.Application.Dto.Cart;
using E_Commerce.Application.Services.Interfaces.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartServices cartServices;

        public CartsController(ICartServices cartServices)
        {
            this.cartServices = cartServices;
        }
        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout(Checkout checkout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await cartServices.Checkout(checkout);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost("Save-Checkout")]
        public async Task<IActionResult> SaveCheckOut(IEnumerable<CreateAcheive> createAcheives)
        {
            var result=await cartServices.SaveCheckoutHistory(createAcheives);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
