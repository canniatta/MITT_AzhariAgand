using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;

namespace AppManagementDataUser.BusinessLayer.Interface
{
    internal interface IBOUserProfile
    {
        Task<ResultBase<List<BMUserProfile>>> GetDataUserProfile();
        Task<ResultBase<BMUserProfile>> CreateDataUserProfile(BMUserProfile requestData);
    }
}
