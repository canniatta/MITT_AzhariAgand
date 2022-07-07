using System.ComponentModel.DataAnnotations;

namespace AppManagementDataUser.BusinessLayer.BindingModel
{
    public class BMToken
    {
        [Required][MaxLength(50)] public string userName { get; set; } = string.Empty;
        [Required][MaxLength(50)] public string host { get; set; } = string.Empty;
        [Required] public string apiKey { get; set; } = string.Empty;
    }
}
