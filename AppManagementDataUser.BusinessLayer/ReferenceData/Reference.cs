using AppManagementDataUser.BusinessLayer.BindingModel;
using AppManagementDataUser.BusinessLayer.BindingModelResult;
using AppManagementDataUser.DataAccess.Context;
using AppManagementDataUser.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AppManagementDataUser.BusinessLayer.ReferenceData
{
    public class Reference
    {
        private readonly DBContext db;
        public Reference(DBContext dbContext)
        {
            db = dbContext;
        }
        public async Task<List<UserProfile>> GetAllDataUserProfile()
        {
            List<UserProfile> resultData = await db.UserProfiles.ToListAsync();
            return resultData;
        }
        public async Task<UserProfile?> GetDataUserProfileByUserName(string username)
        {
            UserProfile? result = await db.UserProfiles.Where(x => x.Username.Equals(username)).FirstOrDefaultAsync();
            return result;
        }
        public async Task<User?> GetDataUserByUsername(string username)
        {
            User? result = await db.Users.Where(x => x.Username.Equals(username)).FirstOrDefaultAsync();
            return result;
        }
        public async ValueTask<bool> InsertDataUserProfile(BMUserProfile dataUserProfile)
        {
            try
            {
                UserProfile insertData = new()
                {
                    Username = dataUserProfile.username,
                    Name = dataUserProfile.name,
                    Address = dataUserProfile.address,
                    Bod = dataUserProfile.bod,
                    Email = dataUserProfile.email
                };

                await db.AddAsync(insertData);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async ValueTask<(bool, string)> InsertDataUser(BMUser dataUser)
        {
            try
            {
                User insertData = new()
                {
                    Username = dataUser.username,
                    Password = dataUser.password
                };

                await db.AddAsync(insertData);
                await db.SaveChangesAsync();
                return (true, "SUCCESS");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async ValueTask<(bool, int, string)> InsertDataSkill(BMSkill dataSkill)
        {
            try
            {
                Skill insertData = new()
                {
                    SkillName = dataSkill.SkillName.Trim()
                };

                await db.AddAsync(insertData);
                await db.SaveChangesAsync();

                return (true, insertData.SkillId, "SUCCESS");
            }
            catch (Exception ex)
            {
                return (false, 0, ex.Message);
            }
        }
        public async ValueTask<(bool, int, string)> InsertDataSkillLevel(BMSkillLevel dataSkill)
        {
            try
            {
                SkillLevel insertData = new()
                {
                    SkillLevelName = dataSkill.skillLevelName.Trim()
                };

                await db.AddAsync(insertData);
                await db.SaveChangesAsync();

                return (true, insertData.SkillLevelId, "SUCCESS");
            }
            catch (Exception ex)
            {
                return (false, 0, ex.Message);
            }
        }
        public async ValueTask<(bool, string)> UpdateDataSkill(BMRSkill dataSkill)
        {
            try
            {
                Skill? resultData = await db.Skills.FindAsync(dataSkill.SkillID);

                if (resultData is null)
                {
                    return (false, "Skill ID not found");
                }

                resultData.SkillName = dataSkill.SkillName;
                await db.SaveChangesAsync();

                return (true, "SUCCESS");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async ValueTask<(bool, string)> UpdateDataSkillLevel(BMRSkillLevel dataSkill)
        {
            try
            {
                SkillLevel? resultData = await db.SkillLevels.FindAsync(dataSkill.skillLevelID);

                if (resultData is null)
                {
                    return (false, "Skill ID not found");
                }

                resultData.SkillLevelName = dataSkill.skillLevelName;
                await db.SaveChangesAsync();

                return (true, "SUCCESS");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async ValueTask<(bool, int, string)> Delete(int idSkill)
        {
            try
            {
                Skill? resultData = await db.Skills.Where(x => x.SkillId == idSkill).FirstOrDefaultAsync();

                if (resultData is null)
                {
                    return (false, idSkill, "Skill ID not found");
                }

                db.Remove(resultData);
                await db.SaveChangesAsync();

                return (true, idSkill, "SUCCESS DELETE");
            }
            catch (Exception ex)
            {
                return (false, 0, ex.Message);
            }
        }
        public async ValueTask<(bool, int, string)> DeleteSkillLevel(int idSkilllevel)
        {
            try
            {
                SkillLevel? resultData = await db.SkillLevels.Where(x => x.SkillLevelId == idSkilllevel).FirstOrDefaultAsync();

                if (resultData is null)
                {
                    return (false, idSkilllevel, "Skill ID not found");
                }

                db.Remove(resultData);
                await db.SaveChangesAsync();

                return (true, idSkilllevel, "SUCCESS DELETE");
            }
            catch (Exception ex)
            {
                return (false, 0, ex.Message);
            }
        }
        public async Task<List<Skill>> GetAllDataSkill()
        {
            List<Skill> resultData = await db.Skills.ToListAsync();
            return resultData;
        }
        public async Task<List<SkillLevel>> GetAllDataSkillLevel()
        {
            List<SkillLevel> resultData = await db.SkillLevels.ToListAsync();
            return resultData;
        }
        public async Task<Skill?> GetSkillByID(int idskill)
        {
            Skill? resultData = await db.Skills.FindAsync(idskill);
            return resultData;
        }
        public async Task<SkillLevel?> GetSkillLevelByID(int idskillLevel)
        {
            SkillLevel? resultData = await db.SkillLevels.FindAsync(idskillLevel);
            return resultData;
        }
    }
}
