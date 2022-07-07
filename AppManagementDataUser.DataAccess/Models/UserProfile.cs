using System;
using System.Collections.Generic;

namespace AppManagementDataUser.DataAccess.Models
{
    public partial class UserProfile
    {
        public string Username { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime Bod { get; set; }
        public string Email { get; set; } = null!;

        public virtual User UsernameNavigation { get; set; } = null!;
    }
}
