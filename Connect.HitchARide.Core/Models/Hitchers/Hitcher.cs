
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.HitchARide.Core.Models.Hitchers
{

    [TableName("vw_Connect_HitchARide_Hitchers")]
    [DataContract]
    public partial class Hitcher  : HitcherBase 
    {

        #region .ctor
        public Hitcher()  : base() 
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public string Email { get; set; }
        #endregion

        #region Methods
        public HitcherBase GetHitcherBase()
        {
            HitcherBase res = new HitcherBase();
             res.RideId = RideId;
             res.UserId = UserId;
             res.Accepted = Accepted;
             res.Comments = Comments;
            return res;
        }
        #endregion

    }
}
