using SpeedyAir.ly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.ly.Extensions
{
    internal static class LocationIdExtensions
    {
        internal static string GetLocationName(this LocationId locationId)
        {
            switch (locationId)
            {
                case LocationId.YUL: return "Montreal airport";
                case LocationId.YYZ: return "Toronto";
                case LocationId.YYC: return "Calgary";
                case LocationId.YVR: return "Vancouver";
                case LocationId.YYE: return "Northern Rockies";
                default: throw new NotImplementedException();
            }
        }
        internal static LocationId GetLocationId(this string locationShortName)
        {
            if(!Enum.IsDefined(typeof(LocationId),locationShortName))
                return LocationId.Unnknown;
            return Enum.Parse<LocationId>(locationShortName, false);
        }
    }
}
