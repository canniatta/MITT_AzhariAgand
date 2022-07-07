using System.ComponentModel.DataAnnotations;

namespace AppManagementDataUser.BusinessLayer.BindingModelResult
{
    public class BMRUser
    {
        [Required][MaxLength(100)] public string username { get; set; } = string.Empty;
        [Required][MaxLength(100)] public string password { get; set; } = string.Empty;
    }
}
