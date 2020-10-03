using System;
using System.Collections.Generic;
using System.Text;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class City
    {
        public string Name { get; }
        public string Country { get; }
        public int Population { get; }
        public WayPoint Location { get; }

        public City(string n, string c, int p, double lat, double lon)
        {
            Name = n;
            Country = c;
            Population = p;
            Location = new WayPoint(Name, lat, lon);
        }
    }
}
