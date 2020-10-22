﻿using System;
using System.Collections;
using System.Linq;
using Fhnw.Ecnf.RoutePlanner.RoutePlannerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fhnw.Ecnf.RoutePlanner.RoutePlannerTest
{
    [TestClass]
    [DeploymentItem("data/citiesTestDataLab3.txt")]
    [DeploymentItem("data/linksTestDataLab3.txt")]
    [DeploymentItem("data/citiesTestDataLab4.txt")]
    [DeploymentItem("data/linksTestDataLab4.txt")]
    public partial class RouteRequestWatcherTest : RouteRequestWatcher
    {
        private Cities cities3 = new Cities();
        private Links links3;
        private Cities cities4 = new Cities();
        private Links links4;

        [TestInitialize]
        public void Setup()
        {
            cities3.ReadCities(@"citiesTestDataLab3.txt");
            links3 = new Links(cities3);
            links3.ReadLinks(@"linksTestDataLab3.txt");

            cities4.ReadCities(@"citiesTestDataLab4.txt");
            links4 = new Links(cities4);
            links4.ReadLinks(@"linksTestDataLab4.txt");
        }
 

         
        // overwrite GetCurrentDate to take the date to use from the field testDat
        public override DateTime GetCurrentDate => this.testDate;

        // the field testDate is set in each test method
        private DateTime testDate = DateTime.Now;

        [TestMethod]
        public void TestGetBiggestCityOnDay()
        {
            // make some request
            links4.RouteRequested += LogRouteRequests;
            testDate = new DateTime(2019, 1, 31);

            links4.FindShortestRouteBetween("Bern", "Zürich", TransportMode.Rail);
            links4.FindShortestRouteBetween("Bern", "Zürich", TransportMode.Rail);
            links4.FindShortestRouteBetween("Basel", "Bern", TransportMode.Rail);

            Assert.AreEqual(2, GetThreeBiggestCityOnDay(testDate).Count());
            Assert.AreEqual("Zürich", (GetThreeBiggestCityOnDay(testDate).First().Name));

            testDate = new DateTime(2019, 4, 28);

            links4.FindShortestRouteBetween("Bern", "Lyon", TransportMode.Rail);
            links4.FindShortestRouteBetween("Bern", "Zürich", TransportMode.Rail);
            links4.FindShortestRouteBetween("Basel", "Bern", TransportMode.Rail);
            links4.FindShortestRouteBetween("Bern", "Milano", TransportMode.Rail);

            var result = GetThreeBiggestCityOnDay(testDate).ToList();
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Milano", (result[0].Name));
            Assert.AreEqual("Lyon", (result[1].Name));
            Assert.AreEqual("Zürich", (result[2].Name));

            testDate = new DateTime( 2015, 1, 31);
            Assert.AreEqual(0, GetThreeBiggestCityOnDay(testDate).Count());

        }

        [TestMethod]
        public void TestGetLongestCityNamesWithinPeriod()
        {
            // make some request
            links4.RouteRequested += LogRouteRequests;
            testDate = new DateTime(2017, 1, 31);

            links4.FindShortestRouteBetween("Bern", "Zürich", TransportMode.Rail);
            links4.FindShortestRouteBetween("Bern", "Zürich", TransportMode.Rail);
            links4.FindShortestRouteBetween("Basel", "Bern", TransportMode.Rail);

            DateTime from = new DateTime(2017, 1, 1);
            DateTime to = new DateTime(2017, 1, 31);
            var result = GetThreeLongestCityNamesWithinPeriod(from, to).ToList();
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Zürich", result[0].Name);
            Assert.AreEqual("Bern", result[1].Name);

            testDate = new DateTime(2017, 2, 28);

            links4.FindShortestRouteBetween("Bern", "Lyon", TransportMode.Rail);
            links4.FindShortestRouteBetween("Bern", "Dornbirn", TransportMode.Rail);
            links4.FindShortestRouteBetween("Basel", "Winterthur", TransportMode.Rail);
            links4.FindShortestRouteBetween("Bern", "Aarau", TransportMode.Rail);

            from = new DateTime(2017, 1, 1);
            to = new DateTime(2017, 3, 31);
            result = GetThreeLongestCityNamesWithinPeriod(from, to).ToList(); 
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Winterthur".ToLower(), result[0].Name.ToLower());
            Assert.AreEqual("Dornbirn", (result[1].Name));
            Assert.AreEqual("Zürich", (result[2].Name));

            from = new DateTime(2017, 2, 1);
            to = new DateTime(2017, 2, 28);
            result = GetThreeLongestCityNamesWithinPeriod(from, to).ToList();
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("Winterthur".ToLower(), result[0].Name.ToLower());
            Assert.AreEqual("Dornbirn", (result[1].Name));
            Assert.AreEqual("Aarau", (result[2].Name));

            // check with an invalid time range
            from = new DateTime(2017, 12, 1);
            to = new DateTime(2017, 2, 28);
            result = GetThreeLongestCityNamesWithinPeriod(from, to).ToList();
            Assert.AreEqual(0, result.Count());

        }

        [TestMethod]
        public void TestGetNotRequestedCities()
        {
            // make some request
            links4.RouteRequested += LogRouteRequests;
            testDate = new DateTime(2017, 1, 31);

            links4.FindShortestRouteBetween("Bern", "Zürich", TransportMode.Rail);
            links4.FindShortestRouteBetween("Bern", "Zürich", TransportMode.Rail);
            links4.FindShortestRouteBetween("Basel", "Bern", TransportMode.Rail);

            testDate = DateTime.Now;

            links4.FindShortestRouteBetween("Bern", "Lyon", TransportMode.Rail);
            links4.FindShortestRouteBetween("Bern", "Dornbirn", TransportMode.Rail);
            links4.FindShortestRouteBetween("Basel", "Winterthur", TransportMode.Rail);
            links4.FindShortestRouteBetween("Bern", "Aarau", TransportMode.Rail);

            var result = GetNotRequestedCities(cities4).ToList();

            Assert.AreEqual(24, result.Count);

        }

    }
}
