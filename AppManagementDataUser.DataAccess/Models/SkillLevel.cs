using System;
using System.Collections.Generic;

namespace AppManagementDataUser.DataAccess.Models
{
    public partial class SkillLevel
    {
        public SkillLevel()
        {
            UserSkills = new HashSet<UserSkill>();
        }

        public int SkillLevelId { get; set; }
        public string SkillLevelName { get; set; } = null!;

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
