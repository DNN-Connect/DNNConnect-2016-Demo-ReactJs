using System.Web.Mvc;
using DotNetNuke.Web.Mvc.Helpers;
using DotNetNuke.Web.Mvc.Framework;
using System.Web;

namespace Connect.DNN.Modules.HitchARide.Common
{
    public abstract class HitchARideWebPage<TModel> : DnnWebViewPage<TModel>
    {

        public ContextHelper HitchARideModuleContext { get; set; }

        public override void InitHelpers()
        {
            Ajax = new AjaxHelper<TModel>(ViewContext, this);
            Html = new DnnHtmlHelper<TModel>(ViewContext, this);
            Url = new DnnUrlHelper(ViewContext);
            Dnn = new DnnHelper<TModel>(ViewContext, this);
            HitchARideModuleContext = new ContextHelper(ViewContext);
        }

        public string SerializedResources()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(DotNetNuke.Services.Localization.LocalizationProvider.Instance.GetCompiledResourceFile(Dnn.PortalSettings, "/DesktopModules/MVC/Connect/HitchARide/App_LocalResources/ClientResources.resx",
                    System.Threading.Thread.CurrentThread.CurrentCulture.Name));
        }

        public string Locale
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            }
        }

    }
}