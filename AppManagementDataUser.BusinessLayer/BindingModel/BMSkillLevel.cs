using System.ComponentModel.DataAnnotations;

namespace AppManagementDataUser.BusinessLayer.BindingModel
{
    public class BMSkillLevel
    {
        [Required][MaxLength(500)] public string skillLevelName { get; set; } = string.Empty;
    }
}
