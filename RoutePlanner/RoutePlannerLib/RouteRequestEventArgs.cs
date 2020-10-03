using System;
using System.Dynamic;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class RouteRequestEventArgs : EventArgs

    {
        public City FromCity { get; set; }
        public City ToCity { get; set; }
        public TransportMode Mode { get; set; }

        public RouteRequestEventArgs(City a, City b, TransportMode tm)
        {
            FromCity = a;
            ToCity = b;
            Mode = tm;
        }
    }
}