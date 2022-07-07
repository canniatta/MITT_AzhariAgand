using System;
using System.Collections.Generic;

namespace AppManagementDataUser.DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            UserSkills = new HashSet<UserSkill>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
