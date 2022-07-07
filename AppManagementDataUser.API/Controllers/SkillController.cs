using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BusinessObject;
using AppManagementDataUser.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace AppManagementDataUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly BOSkill boSkill;
        public SkillController(DBContext db)
        {
            boSkill = new(db);
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(BMSkill requestData)
        {
            var finalResult = await boSkill.InsertSkill(requestData);
            if (!finalResult.IsOk)
                return BadRequest(finalResult);

            return Ok(finalResult);
        }
        [Route("GetSkill")]
        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var finalResult = await boSkill.GetAllSkill();
            if (!finalResult.IsOk)
                return BadRequest(finalResult);

            return Ok(finalResult);
        }
    }
}
