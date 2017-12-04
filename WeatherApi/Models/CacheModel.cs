using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApi.Models
{
    public class CacheModel
    {
        public CacheModel()
        {
            GuidId = Guid.NewGuid();
        }
        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public DateTime CreateDate { get; set; }
    }
}