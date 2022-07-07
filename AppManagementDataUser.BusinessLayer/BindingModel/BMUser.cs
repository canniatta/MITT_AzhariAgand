using System.ComponentModel.DataAnnotations;

namespace AppManagementDataUser.BusinessLayer.BindingModel
{
    public class BMUser
    {
        [Required][MaxLength(100)] public string username { get; set; } = string.Empty;
        [Required][MaxLength(100)] public string password { get; set; } = string.Empty;
    }
}
