using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreAPISample.Models
{
    public class PagingOptions
    {
        [Range(1, 9999, ErrorMessage = "Offset must be between 0 and 9999" )]
        public int? Offset { get; set; }

        [Range(1, 100, ErrorMessage = "Limit must be between 0 and 100")]
        public int? Limit { get; set; }
    }
}
