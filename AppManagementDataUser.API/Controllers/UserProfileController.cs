using AppManagementDataUser.BusinessLayer.BusinessObject;
using Microsoft.AspNetCore.Mvc;

namespace AppManagementDataUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly BOUserProfile boUserProfile;
        public UserProfileController()
        {

        }
        //[HttpPost]
        //public async Task<IActionResult> AddNewUserProfile()
        //{

        //}
    }
}
