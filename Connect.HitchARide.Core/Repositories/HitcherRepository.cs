using System;
using System.Collections.Generic;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.HitchARide.Core.Models.Hitchers;

namespace Connect.HitchARide.Core.Repositories
{

	public class HitcherRepository : ServiceLocator<IHitcherRepository, HitcherRepository>, IHitcherRepository
 {
        protected override Func<IHitcherRepository> GetFactory()
        {
            return () => new HitcherRepository();
        }
        public IEnumerable<Hitcher> GetHitchersByRide(int rideId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<Hitcher>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}vw_Connect_HitchARide_Hitchers WHERE RideId=@0",
                    rideId);
            }
        }
        public Hitcher GetHitcher(int rideId, int userId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<Hitcher>(System.Data.CommandType.Text,
                    "SELECT * FROM {databaseOwner}{objectQualifier}vw_Connect_HitchARide_Hitchers WHERE RideId=@0 AND UserId=@1",
                    rideId,userId);
            }
        }
        public void AddHitcher(HitcherBase hitcher)
        {
            Requires.NotNull(hitcher);
            Requires.NotNull(hitcher.RideId);
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.Text,
                    "IF NOT EXISTS (SELECT * FROM {databaseOwner}{objectQualifier}Connect_HitchARide_Hitchers " +
                    "WHERE RideId=@0 AND UserId=@1) " +
                    "INSERT INTO {databaseOwner}{objectQualifier}Connect_HitchARide_Hitchers (RideId, UserId, Accepted, Comments) " +
                    "SELECT @0, @1, @2, @3", hitcher.RideId, hitcher.UserId, hitcher.Accepted, hitcher.Comments);
            }
        }
        public void DeleteHitcher(HitcherBase hitcher)
        {
            DeleteHitcher(hitcher.RideId, hitcher.UserId);
        }
        public void DeleteHitcher(int rideId, int userId)
        {
             Requires.NotNull(rideId);
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.Text,
                    "DELETE FROM {databaseOwner}{objectQualifier}vw_Connect_HitchARide_Hitchers WHERE RideId=@0 AND UserId=@1",
                    rideId,userId);
            }
        }
        public void DeleteHitchersByRide(int rideId)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.Text,
                    "DELETE FROM {databaseOwner}{objectQualifier}vw_Connect_HitchARide_Hitchers WHERE RideId=@0",
                    rideId);
            }
        }
        public void UpdateHitcher(HitcherBase hitcher)
        {
            Requires.NotNull(hitcher);
            Requires.NotNull(hitcher.RideId);
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<HitcherBase>();
                rep.Update("SET Accepted=@0, Comments=@1 WHERE RideId=@2 AND UserId=@3",
                          hitcher.Accepted,hitcher.Comments, hitcher.RideId,hitcher.UserId);
            }
        } 
 }

    public interface IHitcherRepository
    {
        IEnumerable<Hitcher> GetHitchersByRide(int rideId);
        Hitcher GetHitcher(int rideId, int userId);
        void AddHitcher(HitcherBase hitcher);
        void DeleteHitcher(HitcherBase hitcher);
        void DeleteHitcher(int rideId, int userId);
        void DeleteHitchersByRide(int rideId);
        void UpdateHitcher(HitcherBase hitcher);
    }
}

