using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using Newtonsoft.Json.Linq;
using WeatherApi.Models;
using static System.Configuration.ConfigurationManager;

namespace WeatherApi
{
    public static class Global
    {
        public static string WeatherApiKey { get; } = AppSettings["WeatherApiKey"].ToString();
        public static string GoogleMapApiKey { get; } = AppSettings["GoogleMapApiKey"].ToString();
        public static int QueueWaitingTime { get; } = Convert.ToInt32(AppSettings["QueueWaitingTime"]);
        public static DateTime QueueBeginTime { get; set; } = DateTime.Now;

        public static IList<City> Cities = new List<City>();
        public static LanguageResponse LanguageResponse { get; private set; }
        public static IList<KeyValuePair> IconSet = new List<KeyValuePair>();
        public static IList<string> DateRanges = new List<string>();
        public static IList<string> Months = new List<string>();
        public static IList<CacheModel> CacheList = new List<CacheModel>();

        static Global()
        {
            Cities.Add(new City { Name = "Antalya", Key = "00000.1.17302", ParentKey = "", CountryCode = "TR" });
            Cities.Add(new City { Name = "Istanbul", Key = "00000.124.17060", ParentKey = "", CountryCode = "TR" });


            var path = HostingEnvironment.MapPath($"~/LanguageCodes.json");
            using (var reader = new StreamReader(path))
            {
                var json = reader.ReadToEnd();
                var obj = JObject.Parse(@json);
                LanguageResponse = obj.ToObject<LanguageResponse>();
            }

            #region Caches

            var targetPath = HostingEnvironment.MapPath("~/Caches");
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            var documentList = Directory.GetFiles(targetPath);
            foreach (var document in documentList)
            {
                CacheList.Add(new CacheModel()
                {
                    Name = Path.GetFileNameWithoutExtension(document),
                    CreateDate = System.IO.File.GetLastWriteTime(document),
                    FullPath = document
                });
            }

            #endregion

            DateRanges.Add("01010131");
            DateRanges.Add("02010228");
            DateRanges.Add("03010331");
            DateRanges.Add("04010430");
            DateRanges.Add("05010531");
            DateRanges.Add("06010630");
            DateRanges.Add("07010731");
            DateRanges.Add("08010831");
            DateRanges.Add("09010930");
            DateRanges.Add("10011031");
            DateRanges.Add("11011130");
            DateRanges.Add("12011231");

            if (DateTimeFormatInfo.CurrentInfo != null)
                DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().ForEach(x =>
                {
                    if (!string.IsNullOrEmpty(x))
                        Months.Add(x);
                });

            IconSet.Add(new KeyValuePair { Name = "Icon Set #1", Key = "a" });
            IconSet.Add(new KeyValuePair { Name = "Icon Set #2", Key = "b" });
            IconSet.Add(new KeyValuePair { Name = "Icon Set #3", Key = "c" });
            IconSet.Add(new KeyValuePair { Name = "Icon Set #4", Key = "d" });
            IconSet.Add(new KeyValuePair { Name = "Icon Set #5", Key = "e" });
            IconSet.Add(new KeyValuePair { Name = "Icon Set #6", Key = "f" });
            IconSet.Add(new KeyValuePair { Name = "Icon Set #7", Key = "g" });
            IconSet.Add(new KeyValuePair { Name = "Icon Set #8", Key = "h" });
            IconSet.Add(new KeyValuePair { Name = "Icon Set #9", Key = "i" });
            IconSet.Add(new KeyValuePair { Name = "Icon Set #10", Key = "j" });
            IconSet.Add(new KeyValuePair { Name = "Icon Set #11", Key = "k" });

        }
    }
}