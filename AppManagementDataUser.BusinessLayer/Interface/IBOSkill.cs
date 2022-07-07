using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;

namespace AppManagementDataUser.BusinessLayer.Interface
{
    internal interface IBOSkill
    {
        Task<ResultBase<List<BMRSkill>>> GetAllSkill();
        Task<ResultBase<BMRSkill>> GetSkillByID(int idSkill);
        Task<ResultBase<BMRSkill>> InsertSkill(BMSkill requestData);
        Task<ResultBase<BMRSkill>> UpdateSkill(BMRSkill requestData);
        Task<ResultBase<BMRSkill>> DeleteSkill(int idSkill);
    }
}
