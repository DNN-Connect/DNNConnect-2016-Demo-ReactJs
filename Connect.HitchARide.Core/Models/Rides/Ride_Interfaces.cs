
using System;
using System.Data;
using System.Xml.Serialization;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Tokens;

namespace Connect.HitchARide.Core.Models.Rides
{

 [Serializable(), XmlRoot("Ride")]
 public partial class Ride
 {

  #region IHydratable
  public override void Fill(IDataReader dr)
  {
   base.Fill(dr);
   DisplayName = Convert.ToString(Null.SetNull(dr["DisplayName"], DisplayName));
   Email = Convert.ToString(Null.SetNull(dr["Email"], Email));
   CreatedByUser = Convert.ToString(Null.SetNull(dr["CreatedByUser"], CreatedByUser));
   LastModifiedByUser = Convert.ToString(Null.SetNull(dr["LastModifiedByUser"], LastModifiedByUser));
   NrAcceptedHitchers = Convert.ToInt32(Null.SetNull(dr["NrAcceptedHitchers"], NrAcceptedHitchers));
   NrInterestedHitchers = Convert.ToInt32(Null.SetNull(dr["NrInterestedHitchers"], NrInterestedHitchers));
  }
  #endregion

  #region IPropertyAccess
  public override string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
  {
   switch (strPropertyName.ToLower()) {
    case "displayname": // NVarChar
     return PropertyAccess.FormatString(DisplayName, strFormat);
    case "email": // NVarChar
     if (Email == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Email, strFormat);
    case "createdbyuser": // NVarChar
     if (CreatedByUser == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(CreatedByUser, strFormat);
    case "lastmodifiedbyuser": // NVarChar
     if (LastModifiedByUser == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(LastModifiedByUser, strFormat);
    case "nracceptedhitchers": // Int
     if (NrAcceptedHitchers == null)
     {
         return "";
     };
     return ((int)NrAcceptedHitchers).ToString(strFormat, formatProvider);
    case "nrinterestedhitchers": // Int
     if (NrInterestedHitchers == null)
     {
         return "";
     };
     return ((int)NrInterestedHitchers).ToString(strFormat, formatProvider);
    default:
       return base.GetProperty(strPropertyName, strFormat, formatProvider, accessingUser, accessLevel, ref propertyNotFound);
   }
  }
  #endregion

 }
}

