using System.Web.Mvc;
using Connect.DNN.Modules.HitchARide.Common;

namespace Connect.DNN.Modules.HitchARide.Controllers
{
    public class HomeController: HitchARideMvcController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(HitchARideModuleContext.Settings.View);
        }
    }
}
