using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
