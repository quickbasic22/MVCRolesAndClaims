using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using MVCRolesAndClaims.Areas.Identity.ViewModels;
using System.Diagnostics;

namespace MVCRolesAndClaims.Areas.Identity.Pages.Account.Manage
{
    public class CreateRoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        [BindProperty]
        public CreateRoleViewModel CreateRoleViewModel { get; set; }

        public CreateRoleModel(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
            CreateRoleViewModel = new CreateRoleViewModel();
        }
       
        public RedirectToPageResult OnPost()
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = CreateRoleViewModel.RoleName
                };

                try
                {
                    IdentityResult result = _roleManager.CreateAsync(identityRole).Result;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                
               

                if (result.Succeeded)
                {
                    return RedirectToPage("Index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("pageErrors", error.Description);
                }
            }
            
            return RedirectToPage("CreateRole");
        }
       
    }
}
