

using Microsoft.Build.Framework;

namespace MVCRolesAndClaims.Areas.Identity.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
