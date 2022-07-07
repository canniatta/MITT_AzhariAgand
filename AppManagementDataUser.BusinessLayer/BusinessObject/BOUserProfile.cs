using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;
using AppManagementDataUser.DataAccess.Context;
using AppManagementDataUser.DataAccess.Models;

namespace AppManagementDataUser.BusinessLayer.BusinessObject
{
    public class BOUserProfile
    {
        private readonly ReferenceData.Reference boReference;
        private readonly ResponseCodeError.ResponseCode responseCode;
        public BOUserProfile(DBContext db)
        {
            boReference = new(db);
            responseCode = new();
        }
        public async Task<ResultBase<List<BMUserProfile>>> GetDataUserProfile()
        {
            var result = new ResultBase<List<BMUserProfile>>
            {
                Data = new()
            };

            try
            {
                List<BMUserProfile> profileUserList = new();
                var getDataUserProfile = await boReference.GetAllDataUserProfile();
                if (getDataUserProfile.Count == 0)
                {
                    
                }
                for (int i = 0; i < getDataUserProfile.Count; i++)
                {
                    BMUserProfile dataUserProfile = new()
                    {
                        username = getDataUserProfile[i].Username,
                        name = getDataUserProfile[i].Name,
                        address = getDataUserProfile[i].Address,
                        bod = getDataUserProfile[i].Bod,
                        email = getDataUserProfile[i].Email,
                    };
                    result.Data.Add(dataUserProfile);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            
            return result;
        }
        public async Task<ResultBase<BMUserProfile>> CreateDataUserProfile(BMUserProfile requestData)
        {
            var result = new ResultBase<BMUserProfile>
            {
                Data = new()
            };

            try
            {
                #region Validation Data

                User? getdataUser = await boReference.GetDataUserByUsername(requestData.username.Trim());
                if (getdataUser is null)
                {
                    result.IsOk = false;
                    result.Message = responseCode.GetEnumDesc(ResponseCodeError.ResponseCode.errorList.MI008);
                    result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI008.ToString();
                    return result;
                }

                UserProfile ? dataUserProfile = await boReference.GetDataUserProfileByUserName(requestData.username.Trim());
                if (dataUserProfile is not null)
                {
                    result.IsOk = false;
                    result.Message = responseCode.GetEnumDesc(ResponseCodeError.ResponseCode.errorList.MI001);
                    result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI001.ToString();
                    return result;
                }
                if (dataUserProfile is not null)
                {
                    if (dataUserProfile.Email.Contains(requestData.email))
                    {
                        result.IsOk = false;
                        result.Message = responseCode.GetEnumDesc(ResponseCodeError.ResponseCode.errorList.MI002);
                        result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI002.ToString();
                        return result;
                    }
                }
                
                #endregion

                var processInsert = await boReference.InsertDataUserProfile(requestData);
                if (!processInsert)
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.IsOk = false;
                result.Message = ex.Message;
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI999.ToString();
            }
            
            return result;
        }
    }
}
