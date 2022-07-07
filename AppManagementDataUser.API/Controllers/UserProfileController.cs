using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BusinessObject;
using AppManagementDataUser.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace AppManagementDataUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly BOUserProfile boUserProfile;
        public UserProfileController(DBContext db)
        {
            boUserProfile = new(db);
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(BMUserProfile requestData)
        {
            var finalResult = await boUserProfile.CreateDataUserProfile(requestData);
            if (!finalResult.IsOk)
                return BadRequest(finalResult);

            return Ok(finalResult);
        }
        [Route("GetUserProfile")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfile()
        {
            var finalResult = await boUserProfile.GetDataUserProfile();
            if (!finalResult.IsOk)
                return BadRequest(finalResult);

            return Ok(finalResult);
        }
    }
}
