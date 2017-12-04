using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Hosting;
using Newtonsoft.Json.Linq;
using WeatherApi.Models;
using static WeatherApi.Global;

namespace WeatherApi
{
    public static class Helper
    {
        public static object ObjectSuccess(dynamic data, string message = "")
        {
            return new
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }

        public static object ObjectError(string message)
        {
            return new
            {
                IsSuccess = false,
                Message = message
            };
        }

        public static T GetResponse<T>(string url, string cacheName) where T : new()
        {
            T targetObj;
            //var path = HostingEnvironment.ApplicationPhysicalPath + "Caches\\" + cacheName;
            var path = HostingEnvironment.MapPath($"~/Caches/{cacheName}");
            if (File.Exists(path))
                targetObj = GetFileToJsonObj<T>(path);              
            else
            {
                CheckQueueTime();

                using (var webClient = new WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;

                    var result = webClient.DownloadString(url);
                    var json = JObject.Parse(result);
                    targetObj = json.ToObject<T>();

                    // ReSharper disable once AssignNullToNotNullAttribute
                    using (var streamWriter = new StreamWriter(path))
                    {
                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
            }
            return targetObj;
        }

        public static T GetFileToJsonObj<T>(string path) where T : new()
        {
            T targetObj;
            try
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                using (var reader = new StreamReader(path))
                {
                    var json = reader.ReadToEnd();
                    var obj = JObject.Parse(json);
                    targetObj = obj.ToObject<T>();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            return targetObj;
        }

        private static void CheckQueueTime()
        {
            var diff = DateTime.Now - QueueBeginTime;
            if (diff.TotalSeconds <= QueueWaitingTime)
            {
                var diffSeconds = (QueueWaitingTime - Convert.ToInt32(Math.Floor(diff.TotalSeconds)) + 1) * 1000;
                Thread.Sleep(diffSeconds);
            }
            QueueBeginTime = DateTime.Now;
        }

        public static string GetTempCssName(this int degree)
        {
            var cssName = string.Empty;

            if (degree <= -21) cssName = ".t-25-21";
            else if (degree >= -20 && degree <= -16) cssName = "t-20-16";
            else if (degree >= -15 && degree <= -11) cssName = "t-15-11";
            else if (degree >= -10 && degree <= -6) cssName = "t-10-6";
            else if (degree >= -5 && degree <= -1) cssName = "t-5-1";
            else if (degree >= 0 && degree <= 4) cssName = "t04";
            else if (degree >= 5 && degree <= 9) cssName = "t59";
            else if (degree >= 10 && degree <= 14) cssName = "t1014";
            else if (degree >= 15 && degree <= 19) cssName = "t1519";
            else if (degree >= 20 && degree <= 24) cssName = "t2024";
            else if (degree >= 25 && degree <= 29) cssName = "t2529";
            else if (degree >= 30 && degree <= 34) cssName = "t3034";
            else if (degree >= 35 && degree <= 39) cssName = "t3539";
            else if (degree >= 40) cssName = "t4045";
            return cssName;
        }
    }

    public static class Extensions
    {
        public static CityPlanner SetColorRangeClass(this CityPlanner cityPlanner)
        {
            cityPlanner.trip.temp_high.avg.CSSName = Convert.ToInt32(cityPlanner.trip.temp_high.avg.C).GetTempCssName();
            //cityPlanner.trip.temp_high.max.CSSName = Convert.ToInt32(cityPlanner.trip.temp_high.max.C).GetTempCSSName();
            //cityPlanner.trip.temp_high.min.CSSName = Convert.ToInt32(cityPlanner.trip.temp_high.min.C).GetTempCSSName();

            cityPlanner.trip.temp_low.avg.CSSName = Convert.ToInt32(cityPlanner.trip.temp_low.avg.C).GetTempCssName();
            //cityPlanner.trip.temp_low.max.CSSName = Convert.ToInt32(cityPlanner.trip.temp_low.max.C).GetTempCSSName();
            //cityPlanner.trip.temp_low.min.CSSName = Convert.ToInt32(cityPlanner.trip.temp_low.min.C).GetTempCSSName();

            cityPlanner.trip.precip.avg.CSSName = "t04";
            cityPlanner.trip.dewpoint_high.avg.CSSName = Convert.ToInt32(cityPlanner.trip.dewpoint_high.avg.C).GetTempCssName();
            cityPlanner.trip.dewpoint_low.avg.CSSName = Convert.ToInt32(cityPlanner.trip.dewpoint_low.avg.C).GetTempCssName();
            return cityPlanner;
        }
    }


}