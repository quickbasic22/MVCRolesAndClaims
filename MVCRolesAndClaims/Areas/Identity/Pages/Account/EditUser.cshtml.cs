using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCRolesAndClaims.Areas.Identity.Data;
using MVCRolesAndClaims.Areas.Identity.ViewModels;
using MVCRolesAndClaims.Data;

namespace MVCRolesAndClaims.Areas.Identity.Pages.Account
{
    public class EditUserModel : PageModel
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;

        public EditUserModel(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;

        }
              
        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            return RedirectToPage("./Index");
        }

    }
}
