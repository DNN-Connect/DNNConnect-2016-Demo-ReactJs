
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.HitchARide.Core.Data;

namespace Connect.HitchARide.Core.Models.Rides
{
    [TableName("Connect_HitchARide_Rides")]
    [PrimaryKey("RideId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]
    public partial class RideBase  : AuditableEntity 
    {

        #region .ctor
        public RideBase()
        {
            RideId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int RideId { get; set; }
        [DataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public bool Incoming { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public int PlacesAvailable { get; set; }
        #endregion

        #region Methods
        public void ReadRideBase(RideBase ride)
        {
            if (ride.RideId > -1)
                RideId = ride.RideId;

            if (ride.ModuleId > -1)
                ModuleId = ride.ModuleId;

            if (ride.UserId > -1)
                UserId = ride.UserId;

            Incoming = ride.Incoming;

            if (!String.IsNullOrEmpty(ride.Location))
                Location = ride.Location;

            if (!String.IsNullOrEmpty(ride.Notes))
                Notes = ride.Notes;

            if (ride.PlacesAvailable > -1)
                PlacesAvailable = ride.PlacesAvailable;

        }
        #endregion

    }
}



