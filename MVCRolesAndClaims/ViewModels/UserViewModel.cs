using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using MVCRolesAndClaims.Models;

namespace MVCRolesAndClaims.ViewModels
{
    [MetadataType(typeof(UserMetadata))]
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailTaken", "Home")]
        //[RemoteServerCilent("IsEmailTaken", "Home")]
        public string? Email { get; set; }
    }

    public class UserMetadata
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailTaken", "Home")]
        //[RemoteServerCilent("IsEmailTaken", "Home")]
        public string? Email { get; set; }
    }
}
