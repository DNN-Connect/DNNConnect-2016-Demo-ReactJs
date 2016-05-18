
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.HitchARide.Core.Models.Rides
{

    [TableName("vw_Connect_HitchARide_Rides")]
    [PrimaryKey("RideId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]                
    public partial class Ride  : RideBase 
    {

        #region .ctor
        public Ride()  : base() 
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string CreatedByUser { get; set; }
        [DataMember]
        public string LastModifiedByUser { get; set; }
        [DataMember]
        public int? NrAcceptedHitchers { get; set; }
        [DataMember]
        public int? NrInterestedHitchers { get; set; }
        #endregion

        #region Methods
        public RideBase GetRideBase()
        {
            RideBase res = new RideBase();
             res.RideId = RideId;
             res.ModuleId = ModuleId;
             res.UserId = UserId;
             res.Incoming = Incoming;
             res.Location = Location;
             res.Notes = Notes;
             res.PlacesAvailable = PlacesAvailable;
  res.CreatedByUserID = CreatedByUserID;
  res.CreatedOnDate = CreatedOnDate;
  res.LastModifiedByUserID = LastModifiedByUserID;
  res.LastModifiedOnDate = LastModifiedOnDate;
            return res;
        }
        #endregion

    }
}
