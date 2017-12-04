using System;

namespace WeatherApi.Models
{
    public class City
    {
        public City()
        {
            GuidId = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }

        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string ParentKey { get; set; }
        public string CountryCode { get; set; }
        private DateTime CreateDate { get; set; }
    }
}