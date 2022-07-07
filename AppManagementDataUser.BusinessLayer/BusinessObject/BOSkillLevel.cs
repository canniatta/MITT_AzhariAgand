using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;
using AppManagementDataUser.BusinessLayer.Interface;
using AppManagementDataUser.DataAccess.Context;

namespace AppManagementDataUser.BusinessLayer.BusinessObject
{
    public class BOSkillLevel : IBOSkillLevel
    {
        private readonly ReferenceData.Reference boReference;
        private readonly ResponseCodeError.ResponseCode responseCode;
        public BOSkillLevel(DBContext db)
        {
            boReference = new(db);
            responseCode = new();
        }
        public async Task<ResultBase<List<BMRSkillLevel>>> GetAllSkillLevel()
        {
            var result = new ResultBase<List<BMRSkillLevel>>()
            {
                Data = new()
            };

            var getAllDataSkill = await boReference.GetAllDataSkillLevel();
            if (getAllDataSkill.Count == 0)
            {
                result.IsOk = false;
                result.Message = responseCode.GetEnumDesc(ResponseCodeError.ResponseCode.errorList.MI007);
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI007.ToString();
                return result;
            }

            for (int i = 0; i < getAllDataSkill.Count; i++)
            {
                BMRSkillLevel dataSkill = new()
                {
                    skillLevelID = getAllDataSkill[i].SkillLevelId,
                    skillLevelName = getAllDataSkill[i].SkillLevelName
                };

                result.Data.Add(dataSkill);
            }

            return result;
        }
        public async Task<ResultBase<BMRSkillLevel>> GetSkillLevelByID(int idSkillLevel)
        {
            var result = new ResultBase<BMRSkillLevel>()
            {
                Data = new()
            };

            var getDataSkillLevel = await boReference.GetSkillLevelByID(idSkillLevel);
            if (getDataSkillLevel is null)
            {
                result.IsOk = false;
                result.Message = responseCode.GetEnumDesc(ResponseCodeError.ResponseCode.errorList.MI006);
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI006.ToString();
                return result;
            }

            result.Data.skillLevelID = getDataSkillLevel.SkillLevelId;
            getDataSkillLevel.SkillLevelName = getDataSkillLevel.SkillLevelName;

            return result;
        }
        public async Task<ResultBase<BMRSkillLevel>> InsertSkillLevel(BMSkillLevel requestData)
        {
            var result = new ResultBase<BMRSkillLevel>()
            {
                Data = new()
            };

            var processInsertData = await boReference.InsertDataSkillLevel(requestData);
            if (!processInsertData.Item1)
            {
                result.IsOk = false;
                result.Message = processInsertData.Item3;
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI999.ToString();
                return result;
            }

            result.Data.skillLevelID = processInsertData.Item2;
            result.Data.skillLevelName = requestData.skillLevelName;

            return result;
        }
        public async Task<ResultBase<BMRSkillLevel>> UpdateSkillLevel(BMRSkillLevel requestData)
        {
            var result = new ResultBase<BMRSkillLevel>()
            {
                Data = new()
            };

            var processInsertData = await boReference.UpdateDataSkillLevel(requestData);
            if (!processInsertData.Item1)
            {
                result.IsOk = false;
                result.Message = processInsertData.Item2;
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI999.ToString();
                return result;
            }

            result.Data.skillLevelID = requestData.skillLevelID;
            result.Data.skillLevelName = requestData.skillLevelName;

            return result;
        }
        public async Task<ResultBase<BMRSkillLevel>> DeleteSkillLevel(int idSkillLevel)
        {
            var result = new ResultBase<BMRSkillLevel>()
            {
                Data = new()
            };

            var getdataskill = await boReference.GetSkillLevelByID(idSkillLevel);
            if (getdataskill is null)
            {
                result.IsOk = false;
                result.Message = responseCode.GetEnumDesc(ResponseCodeError.ResponseCode.errorList.MI006);
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI006.ToString();
                return result;
            }

            var processDeleteData = await boReference.DeleteSkillLevel(idSkillLevel);
            if (!processDeleteData.Item1)
            {
                result.IsOk = false;
                result.Message = processDeleteData.Item3;
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI999.ToString();
                return result;
            }

            result.Message = processDeleteData.Item3;
            result.Data.skillLevelID = getdataskill.SkillLevelId;
            result.Data.skillLevelName = getdataskill.SkillLevelName;

            return result;
        }
    }
}
