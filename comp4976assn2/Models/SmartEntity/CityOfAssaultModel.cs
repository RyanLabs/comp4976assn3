using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class CityOfAssaultModel
    {
        [Key]
        public int CityOfAssaultId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "City OF Assault")]
        public String CityOfAssault { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}