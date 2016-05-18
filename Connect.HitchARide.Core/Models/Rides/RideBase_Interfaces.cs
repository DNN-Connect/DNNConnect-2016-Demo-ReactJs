
using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.HitchARide.Core.Models.Rides
{
    public partial class RideBase : IHydratable, IPropertyAccess
    {

        #region IHydratable

        public virtual void Fill(IDataReader dr)
        {
            FillAuditFields(dr);
   RideId = Convert.ToInt32(Null.SetNull(dr["RideId"], RideId));
   ModuleId = Convert.ToInt32(Null.SetNull(dr["ModuleId"], ModuleId));
   UserId = Convert.ToInt32(Null.SetNull(dr["UserId"], UserId));
   Incoming = Convert.ToBoolean(Null.SetNull(dr["Incoming"], Incoming));
   Location = Convert.ToString(Null.SetNull(dr["Location"], Location));
   Notes = Convert.ToString(Null.SetNull(dr["Notes"], Notes));
   PlacesAvailable = Convert.ToInt32(Null.SetNull(dr["PlacesAvailable"], PlacesAvailable));
        }

        [IgnoreColumn()]
        public int KeyID
        {
            get { return RideId; }
            set { RideId = value; }
        }
        #endregion

        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "rideid": // Int
     return RideId.ToString(strFormat, formatProvider);
    case "moduleid": // Int
     return ModuleId.ToString(strFormat, formatProvider);
    case "userid": // Int
     return UserId.ToString(strFormat, formatProvider);
    case "incoming": // Bit
     return Incoming.ToString();
    case "location": // NVarChar
     return PropertyAccess.FormatString(Location, strFormat);
    case "notes": // NVarCharMax
     return PropertyAccess.FormatString(Notes, strFormat);
    case "placesavailable": // Int
     return PlacesAvailable.ToString(strFormat, formatProvider);
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

