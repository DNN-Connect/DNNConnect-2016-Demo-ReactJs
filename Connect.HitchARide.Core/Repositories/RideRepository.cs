using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Collections;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.HitchARide.Core.Data;
using Connect.HitchARide.Core.Models.Rides;

namespace Connect.HitchARide.Core.Repositories
{

	public class RideRepository : ServiceLocator<IRideRepository, RideRepository>, IRideRepository
 {
        protected override Func<IRideRepository> GetFactory()
        {
            return () => new RideRepository();
        }
        public IEnumerable<Ride> GetRides(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Ride>();
                return rep.Get(moduleId);
            }
        }
        public IEnumerable<Ride> GetRidesByUser(int userId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<Ride>(System.Data.CommandType.Text,
                    "SELECT * FROM vw_Connect_HitchARide_Rides WHERE UserId=@0",
                    userId);
            }
        }
        public Ride GetRide(int moduleId, int rideId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<Ride>();
                return rep.GetById(rideId, moduleId);
            }
        }
        public int AddRide(ref RideBase ride, int userId)
        {
            Requires.NotNull(ride);
            Requires.PropertyNotNegative(ride, "ModuleId");
            ride.CreatedByUserID = userId;
            ride.CreatedOnDate = DateTime.Now;
            ride.LastModifiedByUserID = userId;
            ride.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<RideBase>();
                rep.Insert(ride);
            }
            return ride.RideId;
        }
        public void DeleteRide(RideBase ride)
        {
            Requires.NotNull(ride);
            Requires.PropertyNotNegative(ride, "RideId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<RideBase>();
                rep.Delete(ride);
            }
        }
        public void DeleteRide(int moduleId, int rideId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<RideBase>();
                rep.Delete("WHERE ModuleId = @0 AND RideId = @1", moduleId, rideId);
            }
        }
        public void UpdateRide(RideBase ride, int userId)
        {
            Requires.NotNull(ride);
            Requires.PropertyNotNegative(ride, "RideId");
            ride.LastModifiedByUserID = userId;
            ride.LastModifiedOnDate = DateTime.Now;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<RideBase>();
                rep.Update(ride);
            }
        } 
 }

    public interface IRideRepository
    {
        IEnumerable<Ride> GetRides(int moduleId);
        IEnumerable<Ride> GetRidesByUser(int userId);
        Ride GetRide(int moduleId, int rideId);
        int AddRide(ref RideBase ride, int userId);
        void DeleteRide(RideBase ride);
        void DeleteRide(int moduleId, int rideId);
        void UpdateRide(RideBase ride, int userId);
    }
}

