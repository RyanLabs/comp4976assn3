using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class AgeModel
    {
        [Key]
        public int AgeId { get; set; }
        public String Age { get; set; }
        public ICollection<AgeModel> Clients { get; set; }
    }
}