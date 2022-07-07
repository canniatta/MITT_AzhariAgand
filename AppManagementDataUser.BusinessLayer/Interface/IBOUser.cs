using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;

namespace AppManagementDataUser.BusinessLayer.Interface
{
    internal interface IBOUser
    {
        Task<ResultBase<BMRUser>> RegisterdataUser(BMUser requestData);
    }
}
