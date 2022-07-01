using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.Data.BL;
using Payments.Data.PaymentsContext;
using Payments.Data.PaymentsDtos;
using System.Threading.Tasks;

namespace Payments.Cards.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardManagementController : ControllerBase
    {
        private ICardBL _iCardBL;

        public CardManagementController(ICardBL cardsBL)
        {
            _iCardBL = cardsBL;
        }
        

        [HttpPost("createcard")]
        public async Task<IActionResult> PostCard(CardDTO card)
        {
            Card createdCard = await _iCardBL.CreateCard(card);

            if(createdCard != null)
            {
                return Ok(createdCard);
            }

            return BadRequest(new { message = "Account number exist in our DB" });
        }

    }
}
