
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.HitchARide.Core.Data;

namespace Connect.HitchARide.Core.Models.Hitchers
{
    [TableName("Connect_HitchARide_Hitchers")]
    [DataContract]
    public partial class HitcherBase     {

        #region .ctor
        public HitcherBase()
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public int RideId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public bool Accepted { get; set; }
        [DataMember]
        public string Comments { get; set; }
        #endregion

        #region Methods
        public void ReadHitcherBase(HitcherBase hitcher)
        {
            if (hitcher.RideId > -1)
                RideId = hitcher.RideId;

            if (hitcher.UserId > -1)
                UserId = hitcher.UserId;

            Accepted = hitcher.Accepted;

            if (!String.IsNullOrEmpty(hitcher.Comments))
                Comments = hitcher.Comments;

        }
        #endregion

    }
}



