using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;
using AppManagementDataUser.DataAccess.Context;
using AppManagementDataUser.DataAccess.Models;

namespace AppManagementDataUser.BusinessLayer.BusinessObject
{
    public class BOUser
    {
        private readonly ReferenceData.Reference boReference;
        private readonly ResponseCodeError.ResponseCode responseCode;
        public BOUser(DBContext db)
        {
            boReference = new(db);
            responseCode = new();
        }
        public async Task<ResultBase<BMRUser>> RegisterdataUser(BMUser requestData)
        {
            var result = new ResultBase<BMRUser>()
            {
                Data = new()
            };

            #region Validasi
            User? dataUser = await boReference.GetDataUserByUsername(requestData.username);
            if (dataUser is not null)
            {
                result.IsOk = false;
                result.Message = responseCode.GetEnumDesc(ResponseCodeError.ResponseCode.errorList.MI001);
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI001.ToString();
                return result;
            }

            var processInsertData = await boReference.InsertDataUser(requestData);
            if (!processInsertData.Item1)
            {
                result.IsOk = false;
                result.Message = processInsertData.Item2;
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI999.ToString();
                return result;
            }

            result.Data.username = requestData.username;
            result.Data.password = requestData.password;
            #endregion

            return result;
        }
    }
}
