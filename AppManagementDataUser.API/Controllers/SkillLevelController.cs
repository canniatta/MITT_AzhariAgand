using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;
using AppManagementDataUser.BusinessLayer.BusinessObject;
using AppManagementDataUser.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppManagementDataUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillLevelController : ControllerBase
    {
        private readonly BOSkillLevel boSkillLevel;
        public SkillLevelController(DBContext db)
        {
            boSkillLevel = new(db);
        }
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(BMSkillLevel requestData)
        {
            var finalResult = await boSkillLevel.InsertSkillLevel(requestData);
            if (!finalResult.IsOk)
                return BadRequest(finalResult);

            return Ok(finalResult);
        }
        [Route("GetSkill")]
        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var finalResult = await boSkillLevel.GetAllSkillLevel();
            if (!finalResult.IsOk)
                return BadRequest(finalResult);

            return Ok(finalResult);
        }
        [Route("GetSkillByID")]
        [HttpGet]
        public async Task<IActionResult> GetSkillByID([FromQuery] int idSkill)
        {
            var finalResult = await boSkillLevel.GetSkillLevelByID(idSkill);
            if (!finalResult.IsOk)
                return BadRequest(finalResult);

            return Ok(finalResult);
        }
        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(BMRSkillLevel requestData)
        {
            var finalResult = await boSkillLevel.UpdateSkillLevel(requestData);
            if (!finalResult.IsOk)
                return BadRequest(finalResult);

            return Ok(finalResult);
        }
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int idSkillLevel)
        {
            var finalResult = await boSkillLevel.DeleteSkillLevel(idSkillLevel);
            if (!finalResult.IsOk)
                return BadRequest(finalResult);

            return Ok(finalResult);
        }
    }
}
