using FileUploadWebAPIMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace FileUploadWebAPIMVC5.Controllers
{
    [System.Web.Http.RoutePrefix("commute")]
    public class CommuteController : ApiController
    {
        [HttpGet]
        // GET: Commute
        [System.Web.Http.Route("getServiceStatus")]
        public List<Routes> getServiceStatus()
        {
            return StaticData.getServiceStatus();
        }
        [HttpGet]
        // GET: Commute
        [System.Web.Http.Route("getLines")]
        public List<string> getLines()
        {
            return StaticData.getLines();
        }
        [HttpGet]
        // GET: Commute
        [System.Web.Http.Route("gettrains/{lineid}")]
        public List<Trips> gettrains(string lineid)
        {
            List<Trips> lstTrips = null;
            if (LineType.Silver.ToString() == lineid)
            {
                lstTrips = getsilvertrains();
            }
            else if (LineType.Orange.ToString() == lineid) {
                lstTrips = getornagetrains();
            }
            return lstTrips;

        }
        private List<Trips> getsilvertrains() {
            return new List<Trips>()
                        {
                            new Trips()
                            {
                                TripId = 1,
                                ServiceId = 11,
                                ServiceName = "Silver",
                                stoptimes = new StopTimes()
                                {
                                    StopId = 11,
                                    arrivalTime = DateTime.Now,
                                    departureTime = DateTime.Now,
                                    TripId = 1
                                },
                                stops = new Stops()  {  StopDesc = "Foggy Bottom" , StopId = 11 , StopName = "Foggy Bottom"}
                            },
                            new Trips()
                            {
                                TripId = 2,
                                ServiceId = 12,
                                ServiceName = "Silver",
                                stoptimes = new StopTimes()
                                {
                                    StopId = 12,
                                    arrivalTime = DateTime.Now,
                                    departureTime = DateTime.Now,
                                    TripId = 2
                                },
                                stops = new Stops() {  StopDesc = "Farragut West" , StopId = 12 , StopName = "Farragut West"}
                           }
                        };
        }
        private List<Trips> getornagetrains()
        {
            return new List<Trips>()
                        {
                            new Trips()
                            {
                                TripId =32,
                                ServiceId = 21,
                                ServiceName = "Orange",
                                stoptimes = new StopTimes()
                                {
                                    StopId = 21,
                                    arrivalTime = DateTime.Now,
                                    departureTime = DateTime.Now,
                                    TripId = 1
                                },
                                stops = new Stops()  {  StopDesc = "Vienna" , StopId = 22 , StopName = "Vienna"}
                            },
                            new Trips()
                            {
                                TripId = 31,
                                ServiceId = 22,
                                ServiceName = "Orange",
                                stoptimes = new StopTimes()
                                {
                                    StopId = 22,
                                    arrivalTime = DateTime.Now,
                                    departureTime = DateTime.Now,
                                    TripId = 2
                                },
                                stops = new Stops() {  StopDesc = "Dunn Loring" , StopId = 22 , StopName = "Dunn Loring"}
                           }
                        };
        }
    }
}