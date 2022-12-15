using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using MVCRolesAndClaims.Models;
using System.Diagnostics;

namespace MVCRolesAndClaims.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IEmailSender EmailSender { get; set; }

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender)
        {
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
            catch(Exception err) { }
            {
                
            }

            return View();
        }
    }
}