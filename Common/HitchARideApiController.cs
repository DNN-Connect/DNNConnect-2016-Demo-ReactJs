using DotNetNuke.Web.Api;
using System.Net;
using System.Net.Http;

namespace Connect.DNN.Modules.HitchARide.Common
{
    public class HitchARideApiController : DnnApiController
    {
        private ContextHelper _hitcharideModuleContext;
        public ContextHelper HitchARideModuleContext
        {
            get { return _hitcharideModuleContext ?? (_hitcharideModuleContext = new ContextHelper(this)); }
        }

        public HttpResponseMessage ServiceError(string message) {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, message);
        }

        public HttpResponseMessage AccessViolation(string message)
        {
            return Request.CreateResponse(HttpStatusCode.Unauthorized, message);
        }

    }
}