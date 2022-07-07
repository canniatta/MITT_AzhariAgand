using System.ComponentModel.DataAnnotations;

namespace AppManagementDataUser.BusinessLayer.BindingModel
{
    public class BMUserProfile
    {
        [Required][MaxLength(50)] public string username { get; set; } = string.Empty;
        [Required][MaxLength(50)] public string name { get; set; } = string.Empty;
        [Required][MaxLength(500)] public string address { get; set; } = string.Empty;
        [Required] public DateTime bod { get; set; }
        [Required][MaxLength(50)] public string email { get; set; } = string.Empty;
    }
}
