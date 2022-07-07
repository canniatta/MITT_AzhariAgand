using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;
using AppManagementDataUser.BusinessLayer.BusinessObject;
using AppManagementDataUser.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace AppManagementDataUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BOUser boUser;

        public UserController(DBContext db)
        {
            boUser = new(db);
        }

        [HttpPost]
        [ProducesResponseType(401)]
        [ProducesResponseType(typeof(BMRUser), 400)]
        [ProducesResponseType(typeof(BMRUser), 404)]
        [ProducesResponseType(typeof(BMRUser), 200)]
        [ProducesResponseType(typeof(BMRUser), 500)]
        [ProducesResponseType(typeof(BMRUser), 422)]
        public async Task<IActionResult> RegistersDataUser(BMUser request)
        {
            var result = await boUser.RegisterdataUser(request);
            if (!result.IsOk)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
