using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCRolesAndClaims.Areas.Identity.Data;

namespace MVCRolesAndClaims.Areas.Identity.Pages.Account.Manage
{
    public class ListUsersModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        public List<AppUser> Users { get; set; }

        public ListUsersModel(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
            Users = new List<AppUser>();
        }
        public void OnGet()
        {
            var users = _userManager.Users.ToList();
            Users = users.ToList();
        }
    }
}
