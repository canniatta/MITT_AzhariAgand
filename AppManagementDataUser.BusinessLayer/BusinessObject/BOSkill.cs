using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;
using AppManagementDataUser.BusinessLayer.Interface;
using AppManagementDataUser.DataAccess.Context;

namespace AppManagementDataUser.BusinessLayer.BusinessObject
{
    public class BOSkill : IBOSkill
    {
        private readonly ReferenceData.Reference boReference;
        private readonly ResponseCodeError.ResponseCode responseCode;
        public BOSkill(DBContext db)
        {
            boReference = new(db);
            responseCode = new();
        }
        public async Task<ResultBase<List<BMRSkill>>> GetAllSkill()
        {
            var result = new ResultBase<List<BMRSkill>>()
            {
                Data = new()
            };

            var getAllDataSkill = await boReference.GetAllDataSkill();
            if (getAllDataSkill.Count == 0)
            {
                result.IsOk = false;
                result.Message = responseCode.GetEnumDesc(ResponseCodeError.ResponseCode.errorList.MI003);
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI003.ToString();
                return result;
            }

            for (int i = 0; i < getAllDataSkill.Count; i++)
            {
                BMRSkill dataSkill = new()
                {
                    SkillID = getAllDataSkill[i].SkillId,
                    SkillName = getAllDataSkill[i].SkillName
                };

                result.Data.Add(dataSkill);
            }

            return result;
        }
        public async Task<ResultBase<BMRSkill>> GetSkillByID(int idSkill)
        {
            var result = new ResultBase<BMRSkill>()
            {
                Data = new()
            };

            var getDataSkill = await boReference.GetSkillByID(idSkill);
            if (getDataSkill is null)
            {
                result.IsOk = false;
                result.Message = responseCode.GetEnumDesc(ResponseCodeError.ResponseCode.errorList.MI004);
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI004.ToString();
                return result;
            }

            result.Data.SkillID = getDataSkill.SkillId;
            getDataSkill.SkillName = getDataSkill.SkillName;

            return result;
        }
        public async Task<ResultBase<BMRSkill>> InsertSkill(BMSkill requestData)
        {
            var result = new ResultBase<BMRSkill>()
            {
                Data = new()
            };

            var processInsertData = await boReference.InsertDataSkill(requestData);
            if (!processInsertData.Item1)
            {
                result.IsOk = false;
                result.Message = processInsertData.Item3;
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI999.ToString();
                return result;
            }

            result.Data.SkillID = processInsertData.Item2;
            result.Data.SkillName = requestData.SkillName;

            return result;
        }
        public async Task<ResultBase<BMRSkill>> UpdateSkill(BMRSkill requestData)
        {
            var result = new ResultBase<BMRSkill>()
            {
                Data = new()
            };

            var processInsertData = await boReference.UpdateDataSkill(requestData);
            if (!processInsertData.Item1)
            {
                result.IsOk = false;
                result.Message = processInsertData.Item2;
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI999.ToString();
                return result;
            }

            result.Data.SkillID = requestData.SkillID;
            result.Data.SkillName = requestData.SkillName;

            return result;
        }
        public async Task<ResultBase<BMRSkill>> DeleteSkill(int idSkill)
        {
            var result = new ResultBase<BMRSkill>()
            {
                Data = new()
            };

            var getdataskill = await boReference.GetSkillByID(idSkill);
            if (getdataskill is null)
            {
                result.IsOk = false;
                result.Message = responseCode.GetEnumDesc(ResponseCodeError.ResponseCode.errorList.MI004);
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI004.ToString();
                return result;
            }

            var processDeleteData = await boReference.Delete(idSkill);
            if (!processDeleteData.Item1)
            {
                result.IsOk = false;
                result.Message = processDeleteData.Item3;
                result.ResponseCode = ResponseCodeError.ResponseCode.errorList.MI999.ToString();
                return result;
            }

            result.Message = processDeleteData.Item3;
            result.Data.SkillID = getdataskill.SkillId;
            result.Data.SkillName = getdataskill.SkillName;

            return result;
        }
    }
}
