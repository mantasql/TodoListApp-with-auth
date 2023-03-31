using Microsoft.AspNetCore.Mvc;

namespace TodoList_auth.Controllers
{
    public class EntryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
