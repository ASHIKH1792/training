using Microsoft.AspNetCore.Mvc;

namespace DManage.SystemManagement.API.Controllers.Interrnal
{

    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
