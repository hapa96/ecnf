using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{

    public class RouteRequestWatcher
    {

        private Dictionary<City, int> requestCounter;
        public RouteRequestWatcher()
        {
            this.requestCounter = new Dictionary<City, int>();
        }

        //Event Handler for event
        public void LogRouteRequests(object sender, RouteRequestEventArgs e)
        {
            if (!requestCounter.ContainsKey(e.ToCity))
            {
                requestCounter.Add(e.ToCity, 1);
            }
            else
            {
                requestCounter[e.ToCity]++;
            }

            Console.WriteLine("Current Request State");
            Console.WriteLine("---------------------");

            // Iterate over Dictionary
            foreach (KeyValuePair<City, int> entry in requestCounter)
            {
                Console.WriteLine($"ToCity: {entry.Key.Name} has been requested {entry.Value} times");
            }
        }


        public int GetCityRequests(City city)
        {
            if (requestCounter.ContainsKey(city))
            {
                return requestCounter[city];

            }
            return 0;

        }
    }
}
