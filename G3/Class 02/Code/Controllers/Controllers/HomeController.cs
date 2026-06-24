using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello class, we are returning result via HTTP";
        }
    }
}
