using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Web.Api;
using Connect.DNN.Modules.HitchARide.Common;
using Connect.HitchARide.Core.Models.Rides;
using Connect.HitchARide.Core.Repositories;

namespace Connect.DNN.Modules.HitchARide.Api
{
    public class RidesController : HitchARideApiController
    {

        public class AddRideDTO
        {
            public bool Incoming { get; set; }
            public string Location { get; set; }
            public int Places { get; set; }
            public string Notes { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HitchARideAuthorize(SecurityLevel = SecurityAccessLevel.Traveller)]
        public HttpResponseMessage Add(AddRideDTO data)
        {
            var ride = new RideBase
            {
                ModuleId = ActiveModule.ModuleID,
                UserId = UserInfo.UserID,
                Incoming = data.Incoming,
                Location = data.Location,
                PlacesAvailable = data.Places,
                Notes = data.Notes
            };
            var newId = RideRepository.Instance.AddRide(ref ride, UserInfo.UserID);
            return Request.CreateResponse(HttpStatusCode.OK, RideRepository.Instance.GetRide(ActiveModule.ModuleID, newId));
        }

    }
}