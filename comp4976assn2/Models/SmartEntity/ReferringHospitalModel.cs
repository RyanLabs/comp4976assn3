using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class ReferringHospitalModel
    {
        [Key]
        public int ReferringHospitalId { get; set; }
        public String ReferringHospital { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}