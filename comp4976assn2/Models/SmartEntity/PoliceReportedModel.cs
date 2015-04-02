using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class PoliceReportedModel
    {
        [Key]
        public int PoliceReportedId { get; set; }
        public String PoliceReported { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}