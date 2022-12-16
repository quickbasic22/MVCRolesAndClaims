using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCRolesAndClaims.Areas.Identity.Data;
using MVCRolesAndClaims.Areas.Identity.ViewModels;

namespace MVCRolesAndClaims.Data;

public class MVCDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    public MVCDbContext(DbContextOptions<MVCDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
