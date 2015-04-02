using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class HospitalAttendedModel
    {
        [Key]
        public int HospitalAttendedId { get; set; }
        public String HospitalAttended { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}