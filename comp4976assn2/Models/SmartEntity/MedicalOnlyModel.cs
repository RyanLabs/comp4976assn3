using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class MedicalOnlyModel
    {
        [Key]
        public int MedicalOnlyId { get; set; }
        public String MedicalOnly { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}