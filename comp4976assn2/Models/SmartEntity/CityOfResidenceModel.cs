using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class CityOfResidenceModel
    {
        [Key]
        public int CityOfResidenceId { get; set; }
        public String CityOfResidence { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}