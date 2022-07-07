using System.ComponentModel.DataAnnotations;

namespace AppManagementDataUser.BusinessLayer.BindingModelResult
{
    public class BMRSkill
    {
        public int SkillID { get; set; }
        [Required][MaxLength(500)] public string SkillName { get; set; } = string.Empty;
    }
}
