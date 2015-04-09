using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class ReferredToCBVSModel
    {
        [Key]
        public int ReferredToCBVSId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Referral CBVS")]
        public String ReferredToCBVS { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}