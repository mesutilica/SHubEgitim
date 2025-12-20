using Microsoft.AspNetCore.Mvc;

namespace NetCoreMVCEgitimi.Controllers
{
    public class MVC14AppSettingController : Controller
    {
        private readonly IConfiguration _configuration;

        public MVC14AppSettingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.Mesaj = $"Email: {_configuration["Email"]}";
            ViewBag.Mesaj += $"<br>MailSunucu: {_configuration["MailSunucu"]}";
            ViewBag.Mesaj += $"<br>UserName: {_configuration["MailKullanici:UserName"]}";
            ViewBag.Mesaj += $"<br>Password: {_configuration["MailKullanici:Password"]}";
            return View();
        }
    }
}
