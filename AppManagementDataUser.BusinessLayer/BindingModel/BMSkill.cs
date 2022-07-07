using System.ComponentModel.DataAnnotations;

namespace AppManagementDataUser.BusinessLayer.BindingModel
{
    public class BMSkill
    {
        [Required][MaxLength(500)] public string SkillName { get; set; } = string.Empty;
    }
}
