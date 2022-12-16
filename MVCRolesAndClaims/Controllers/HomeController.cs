using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVCRolesAndClaims.Areas.Identity.Data;
using MVCRolesAndClaims.Models;
using System.Diagnostics;

namespace MVCRolesAndClaims.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        public IEmailSender EmailSender { get; set; }

        public HomeController(UserManager<AppUser> userManager, ILogger<HomeController> logger, IEmailSender emailSender)
        {
            this._userManager = userManager;
            _logger = logger;
            this.EmailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Send(string toAddress)
        {
            var subject = "Welcome to David Website";
            var body = $"Dave's Dotnet MVC Core website {DateTime.Now}";
            try
            {
                await EmailSender.SendEmailAsync("quickbasic2017@gmail.com", subject, body);
            }
            catch (Exception err)
            {

            }

            return View();
        }

        public IActionResult ManageUsers(string id)
        {
            AppUser user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                user = new AppUser();
            }
            ViewData["user"] = user;
            return View(user);
        }
    }
}
    

