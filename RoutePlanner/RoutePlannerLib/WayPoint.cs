using System;
using System.Globalization;
using System.Threading;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class WayPoint
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public WayPoint(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return FormattableString.Invariant($"WayPoint: {Latitude:N2}/{Longitude:N2}");
            }
            return FormattableString.Invariant($"WayPoint: {Name} {Latitude:N2}/{Longitude:N2}");
        }


        public double Distance(WayPoint target)
        {
            const double R = 6371e3; // meters
            var lat1 = DegreeToRadian(Latitude);
            var lat2 = DegreeToRadian(target.Latitude);
            var dlat = DegreeToRadian(target.Latitude - Latitude);
            var dlon = DegreeToRadian(target.Longitude - Longitude);

            var q = Math.Pow(Math.Sin(dlat/2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon/2), 2);
            var c = 2 * Math.Atan2(Math.Sqrt(q), Math.Sqrt(1 - q));

            return R * c / 1000;
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
