using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVCRolesAndClaims.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AppUser class
public class AppUser : IdentityUser
{
    [Display(Name = "First Name")]
    public virtual string? FirstName { get; set; }
    [Display(Name = "Last Name")]
    public virtual string? LastName { get; set; }
    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    public virtual DateTime BirthDate { get; set; }
    [Display(Name = "Profile Picture")]
    [DataType(DataType.ImageUrl)]
    public virtual string? ProfilePicture { get; set; }
}

