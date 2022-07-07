using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;

namespace AppManagementDataUser.BusinessLayer.Interface
{
    internal interface IBOSkillLevel
    {
        Task<ResultBase<List<BMRSkillLevel>>> GetAllSkillLevel();
        Task<ResultBase<BMRSkillLevel>> GetSkillLevelByID(int idSkillLevel);
        Task<ResultBase<BMRSkillLevel>> InsertSkillLevel(BMSkillLevel requestData);
        Task<ResultBase<BMRSkillLevel>> UpdateSkillLevel(BMRSkillLevel requestData);
        Task<ResultBase<BMRSkillLevel>> DeleteSkillLevel(int idSkillLevel);
    }
}
