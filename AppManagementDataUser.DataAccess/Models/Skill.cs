using System;
using System.Collections.Generic;

namespace AppManagementDataUser.DataAccess.Models
{
    public partial class Skill
    {
        public Skill()
        {
            UserSkills = new HashSet<UserSkill>();
        }

        public int SkillId { get; set; }
        public string SkillName { get; set; } = null!;

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
