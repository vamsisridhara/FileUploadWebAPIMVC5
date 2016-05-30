using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FileUploadWebAPIMVC5.Models
{
    public static class StaticData
    {
        public static List<Routes> getServiceStatus()
        {
            return new List<Routes>()
            {
                new Routes()
                {
                    RouteId = 100,
                    RouteType = LineType.Blue,
                    lineStatus = LineStatus.Alert,
                    cssclass = "info"
                },
                 new Routes()
                {
                    RouteId = 101,
                    RouteType = LineType.Silver,
                    lineStatus = LineStatus.OnTime,
                    cssclass = "success"
                },
                 new Routes()
                {
                    RouteId = 102,
                    RouteType = LineType.Red,
                    lineStatus = LineStatus.Cancelled,
                    cssclass = "warning"
                },
                 new Routes()
                {
                    RouteId = 103,
                    RouteType = LineType.Orange,
                    lineStatus = LineStatus.Delayed,
                    cssclass = "danger"
                }
            };
        }

        public static List<string> getLines()
        {
            return Enum.GetNames(typeof(LineType)).ToList();
        }

        public static Dictionary<string, LineType> getStations()
        {
            Dictionary<string, LineType> dictstations =
                new Dictionary<string, LineType>()
                {
                    { "Whiele-Reston" , LineType.Silver},
                    { "SpringHill" ,  LineType.Silver },
                    { "EastFalls Church", LineType.Orange},
                    { "Ballston", LineType.Orange},
                    { "Rosslyn", LineType.Blue},
                    { "Pentagon", LineType.Blue},
                    {"Farragut North",LineType.Red},
                    {"FriendShipHeights",LineType.Red}
                };
            return dictstations;
        }
    }
    public class Stops
    {
        public int StopId
        {
            get;
            set;
        }
        public string StopName
        {
            get;
            set;
        }
        public string StopDesc
        {
            get;
            set;
        }
    }
    public class Trips
    {
        public int RouteId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName
        {
            get;
            set;
        }
        public StopTimes stoptimes { get; set; }

        public Stops stops { get; set; }
        public int TripId { get; set; }

    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LineType
    {
        [EnumMember(Value = "Silver")]
        Silver,
        [EnumMember(Value = "Red")]
        Red,
        [EnumMember(Value = "Blue")]
        Blue,
        [EnumMember(Value = "Orange")]
        Orange
    }
    public class Routes
    {
        public int RouteId
        {
            get;
            set;
        }
        public LineType RouteType
        {
            get;
            set;
        }
        public LineStatus lineStatus;
        public string cssclass;
    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LineStatus
    {
        [EnumMember(Value = "Cancelled")]
        Cancelled,
        [EnumMember(Value = "Delayed")]
        Delayed,
        [EnumMember(Value = "OnTime")]
        OnTime,
        [EnumMember(Value = "Alert")]
        Alert
    }
    public class StopTimes
    {
        public int TripId
        {
            get;
            set;
        }
        public DateTime arrivalTime
        {
            get;
            set;
        }
        public DateTime departureTime
        {
            get;
            set;
        }
        public int StopId
        {
            get;
            set;
        }

    }
    public class Frequencies
    {
        public int tripid
        {
            get;
            set;
        }
        public DateTime starttime
        {
            get;
            set;
        }
        public DateTime endtime
        {
            get;
            set;
        }
    }
    public class FareRules
    {
        public int fareid
        {
            get;
            set;
        }
        public int routeid
        {
            get;
            set;
        }
        public int orginationid
        {
            get;
            set;
        }
        public int destinationid
        {
            get;
            set;
        }


    }
}