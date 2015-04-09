using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class MultiplePerpetratorsModel
    {
        [Key]
        public int MultiplePerpetratorsId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Multiple Perpetrators")]
        public String MultiplePerpetrators { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}