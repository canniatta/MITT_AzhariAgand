using System.ComponentModel.DataAnnotations;

namespace AppManagementDataUser.BusinessLayer.BindingModelResult
{
    public class BMRToken
    {
        [Required] public string Token { get; set; } = string.Empty;
    }
}
