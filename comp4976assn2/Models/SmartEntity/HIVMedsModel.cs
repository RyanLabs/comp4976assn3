using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class HIVMedsModel
    {
        [Key]
        public int HIVMedsId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "HIV Meds")]
        public String HIVMeds { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}