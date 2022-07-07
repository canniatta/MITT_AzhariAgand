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
        public async Task<List<Skill>> GetAllDataSkill()
        {
            List<Skill> resultData = await db.Skills.ToListAsync();
            return resultData;
        }
        public async Task<Skill?> GetSkillByID(int idskill)
        {
            Skill? resultData = await db.Skills.FindAsync(idskill);
            return resultData;
        }
    }
}
