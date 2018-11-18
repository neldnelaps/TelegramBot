using System.Web.Mvc;

using TestLoymax.Entities;

namespace TestLoymax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UsersDBEntities listclients = new UsersDBEntities(); 
            return View(listclients);
        }
    }
}
