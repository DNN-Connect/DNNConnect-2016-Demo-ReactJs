
using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.HitchARide.Core.Models.Hitchers
{
    public partial class HitcherBase : IHydratable, IPropertyAccess
    {

        #region IHydratable

        public virtual void Fill(IDataReader dr)
        {
   RideId = Convert.ToInt32(Null.SetNull(dr["RideId"], RideId));
   UserId = Convert.ToInt32(Null.SetNull(dr["UserId"], UserId));
   Accepted = Convert.ToBoolean(Null.SetNull(dr["Accepted"], Accepted));
   Comments = Convert.ToString(Null.SetNull(dr["Comments"], Comments));
        }

        [IgnoreColumn()]
        public int KeyID
        {
            get { return Null.NullInteger; }
            set { }
        }
        #endregion

        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "rideid": // Int
     return RideId.ToString(strFormat, formatProvider);
    case "userid": // Int
     return UserId.ToString(strFormat, formatProvider);
    case "accepted": // Bit
     return Accepted.ToString();
    case "comments": // NVarCharMax
     if (Comments == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Comments, strFormat);
                default:
                    propertyNotFound = true;
                    break;
            }

            return Null.NullString;
        }

        [IgnoreColumn()]
        public CacheLevel Cacheability
        {
            get { return CacheLevel.fullyCacheable; }
        }
        #endregion

    }
}

