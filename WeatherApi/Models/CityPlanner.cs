using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApi.Models
{
    public class CityPlanner
    {
        public Response response { get; set; }
        public Trip trip { get; set; }
    }
    public class Trip
    {
        public string title { get; set; }
        public string airport_code { get; set; }
        public string error { get; set; }
        public Period_Of_Record period_of_record { get; set; }
        public Temp_High temp_high { get; set; }
        public Temp_Low temp_low { get; set; }
        public Precip precip { get; set; }
        public Dewpoint_High dewpoint_high { get; set; }
        public Dewpoint_Low dewpoint_low { get; set; }
        public Cloud_Cover cloud_cover { get; set; }
        public Chance_Of chance_of { get; set; }
    }

    public class Period_Of_Record
    {
        public Date_Start date_start { get; set; }
        public Date_End date_end { get; set; }
    }

    public class Date_Start
    {
        public Date date { get; set; }
    }

    public class Date_End
    {
        public Date1 date { get; set; }
    }

    public class Date1
    {
        public string epoch { get; set; }
        public string pretty { get; set; }
        public int? day { get; set; }
        public int? month { get; set; }
        public int? year { get; set; }
        public int? yday { get; set; }
        public int? hour { get; set; }
        public string min { get; set; }
        public int? sec { get; set; }
        public string isdst { get; set; }
        public string monthname { get; set; }
        public string monthname_short { get; set; }
        public string weekday_short { get; set; }
        public string weekday { get; set; }
        public string ampm { get; set; }
        public string tz_short { get; set; }
        public string tz_long { get; set; }
    }

    public class Temp_High
    {
        public Min min { get; set; }
        public Avg avg { get; set; }
        public Max max { get; set; }
    }

    public class Min
    {
        public string F { get; set; }
        public string C { get; set; }
        public string CSSName { get; set; }
    }

    public class Avg
    {
        public string F { get; set; }
        public string C { get; set; }
        public string CSSName { get; set; }
    }

    public class Max
    {
        public string F { get; set; }
        public string C { get; set; }
        public string CSSName { get; set; }
    }

    public class Temp_Low
    {
        public Min min { get; set; }
        public Avg avg { get; set; }
        public Max max { get; set; }
    }

    public class Precip
    {
        public Min2 min { get; set; }
        public Avg2 avg { get; set; }
        public Max2 max { get; set; }
    }

    public class Min2
    {
        public string _in { get; set; }
        public string cm { get; set; }
        public string CSSName { get; set; }
    }

    public class Avg2
    {
        public string _in { get; set; }
        public string cm { get; set; }
        public string CSSName { get; set; }
    }

    public class Max2
    {
        public string _in { get; set; }
        public string cm { get; set; }
        public string CSSName { get; set; }
    }

    public class Dewpoint_High
    {
        public Min min { get; set; }
        public Avg avg { get; set; }
        public Max max { get; set; }
    }

    public class Dewpoint_Low
    {
        public Min min { get; set; }
        public Avg avg { get; set; }
        public Max max { get; set; }
    }

    public class Cloud_Cover
    {
        public string cond { get; set; }
    }

    public class Chance_Of
    {
        public Tempoversixty tempoversixty { get; set; }
        public Chanceofprecip chanceofprecip { get; set; }
        public Chanceofrainday chanceofrainday { get; set; }
        public Chanceofpartlycloudyday chanceofpartlycloudyday { get; set; }
        public Tempoverfreezing tempoverfreezing { get; set; }
        public Chanceofcloudyday chanceofcloudyday { get; set; }
        public Chanceofwindyday chanceofwindyday { get; set; }
        public Chanceofsunnycloudyday chanceofsunnycloudyday { get; set; }
        public Chanceofthunderday chanceofthunderday { get; set; }
        public Chanceofhumidday chanceofhumidday { get; set; }
        public Chanceofsnowonground chanceofsnowonground { get; set; }
        public Chanceoftornadoday chanceoftornadoday { get; set; }
        public Chanceofsultryday chanceofsultryday { get; set; }
        public Tempbelowfreezing tempbelowfreezing { get; set; }
        public Tempoverninety tempoverninety { get; set; }
        public Chanceofhailday chanceofhailday { get; set; }
        public Chanceofsnowday chanceofsnowday { get; set; }
        public Chanceoffogday chanceoffogday { get; set; }
    }

    public class Tempoversixty
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofprecip
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofrainday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofpartlycloudyday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Tempoverfreezing
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofcloudyday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofwindyday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofsunnycloudyday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofthunderday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofhumidday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofsnowonground
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceoftornadoday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofsultryday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Tempbelowfreezing
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Tempoverninety
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofhailday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceofsnowday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

    public class Chanceoffogday
    {
        public string name { get; set; }
        public string description { get; set; }
        public string percentage { get; set; }
    }

}