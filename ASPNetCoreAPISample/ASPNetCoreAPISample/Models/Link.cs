using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreAPISample.Models
{
    public class Link
    {
        public const string GETMETHOD = "GET";

        [JsonProperty(Order = -50)]
        public string HRef { get; set; }

        [JsonProperty(Order = -40, DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(GETMETHOD)]
        public string Method { get; set; }

        [JsonProperty(Order = -30, PropertyName = "Rel", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string[] Relations { get; set; }

        [JsonIgnore]
        public string RouteName { get; set; }

        [JsonIgnore]
        public object RouteValues { get; set; }

        public static Link LinkTo(string routeName, object values)
        => new Link
        {
            RouteName = routeName,
            RouteValues = values,
            Method = GETMETHOD,
            Relations = null
        }; 
    }
}
