using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using MVCRolesAndClaims.Areas.Identity.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MVCRolesAndClaims.Areas.Identity.Pages.Account.Manage
{
    public class CreateRoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        [BindProperty]
        [Required(ErrorMessage = "RoleName is a required string")]
        [StringLength(10, ErrorMessage = "RoleName string length is 10")]
        [PageRemote(PageHandler = "IsRoleTaken", HttpMethod = "get", ErrorMessage = "Sorry RoleName is taken")]
        public string RoleName { get; set; }
        
        public CreateRoleModel(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
            RoleName = string.Empty;
        }
       
        public async Task<IActionResult> OnPost()
        {
            
            IdentityResult result = new IdentityResult();
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = RoleName
                };
                
                try
                {
                    result = await _roleManager.CreateAsync(identityRole);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                
                if (result.Succeeded)
                {
                    return new JsonResult(true);
                }                        
            }

            return new JsonResult(false);
        }
        
        public async Task<JsonResult> IsRoleTaken(string RoleName)
        {
            IdentityRole? roleIfExist = await _roleManager.FindByNameAsync(RoleName);
            if (roleIfExist?.Name == RoleName)
            {
                return new JsonResult(true);
            }
            return new JsonResult(false);
        }
       
    }
}
