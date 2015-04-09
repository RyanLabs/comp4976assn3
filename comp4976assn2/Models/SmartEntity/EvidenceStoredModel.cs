using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class EvidenceStoredModel
    {
        [Key]
        public int EvidenceStoredId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Evidence Stored")]
        public String EvidenceStored { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}