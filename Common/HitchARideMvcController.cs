using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Routing;
using System.Web.Mvc;
using System.Web.Routing;

namespace Connect.DNN.Modules.HitchARide.Common
{
    public class HitchARideMvcController : DnnController
    {

        private ContextHelper _hitcharideModuleContext;
        public ContextHelper HitchARideModuleContext
        {
            get { return _hitcharideModuleContext ?? (_hitcharideModuleContext = new ContextHelper(this)); }
        }

    }
}