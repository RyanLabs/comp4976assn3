using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class DrugFacilitatedAssaultModel
    {
        [Key]
        public int DrugFacilitatedAssaultId { get; set; }
        public String DrugFacilitatedAssault { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}