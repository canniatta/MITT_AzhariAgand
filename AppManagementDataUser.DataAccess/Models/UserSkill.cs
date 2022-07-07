using System;
using System.Collections.Generic;

namespace AppManagementDataUser.DataAccess.Models
{
    public partial class UserSkill
    {
        public string UserSkillId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public int SkillId { get; set; }
        public int SkillLevelId { get; set; }

        public virtual Skill Skill { get; set; } = null!;
        public virtual SkillLevel SkillLevel { get; set; } = null!;
        public virtual User UsernameNavigation { get; set; } = null!;
    }
}
