using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerLib
{
    public class Cities
    {
        private List<City> cities;

        public int Count
        {
            get
            {
                return cities.Count;
            }
        }
        //To search a City by his name
        public City this[string cityName]
        {

            get
            {
                // define Delegate for Comparison
                Predicate<City> compareName = delegate (City c) { return c.Name.Equals(cityName, StringComparison.InvariantCultureIgnoreCase); };
                if (cityName == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    var city = (cities.Find(compareName));
                    if (city != null) return city;
                    else
                    {
                        throw new KeyNotFoundException();
                    }

                }
            }
        }



        public City this[int i]
        {
            get { if (i > 0 || i < cities.Count) { return cities[i]; } else throw new ArgumentOutOfRangeException(); }
            set { cities[i] = value; }
        }

        public Cities()
        {
            cities = new List<City>();
        }

        public int ReadCities(string filename)
        {
            int count = 0;
            using (StreamReader file = new StreamReader(filename))
            {

                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] values = line.Split('\t');
                    AddCity(new City(values[0], values[1], int.Parse(values[2]), double.Parse(values[3]), double.Parse(values[4])));
                    count++;
                }
            }
            return count;
        }

        public int AddCity(City city)
        {
            cities.Add(city);
            return Count;
        }


        public IList<City> FindNeighbours(WayPoint location, double distance)
        {
            return cities.Where(city => city.Location.Distance(location) <= distance).ToList();
        }
    }
}
