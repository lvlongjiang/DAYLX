using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bpmdemoapi.models
{
    [NotMapped]
    public class BaseModels
    {
        
        public string Action { get; set; }
        public string BPMUser { get; set; }
        public string BPMUserPass { get; set; }
        public string FullName { get; set; }
        public string ProcessName { get; set; }


    }
}
