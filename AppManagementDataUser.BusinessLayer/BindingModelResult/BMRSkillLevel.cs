using System.ComponentModel.DataAnnotations;

namespace AppManagementDataUser.BusinessLayer.BindingModelResult
{
    public class BMRSkillLevel
    {
        public int skillLevelID { get; set; }
        [Required][MaxLength(500)] public string skillLevelName { get; set; } = string.Empty;
    }
}
