using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BusinessObject;
using AppManagementDataUser.DataAccess.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppManagementDataUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly BOToken boToken;
        public TokenController(IConfiguration configuration, DBContext dbContext) => boToken = new(configuration, dbContext);

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GenerateToken(BMToken request)
        {
            var finalResult = await boToken.GenerateToken(request);
            if (!finalResult.IsOk)
                return BadRequest(finalResult);

            return Ok(finalResult);
        }
    }
}
