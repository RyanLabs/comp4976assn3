using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class RiskStatusModel
    {
        [Key]
        public int RiskStatusId { get; set; }
        public String RiskStatus { get; set; }
        public ICollection<RiskStatusModel> Clients { get; set; }
    }
}