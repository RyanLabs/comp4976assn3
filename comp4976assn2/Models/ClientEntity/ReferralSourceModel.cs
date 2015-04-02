using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class ReferralSourceModel
    {
        [Key]
        public int ReferralSourceId { get; set; }
        public String ReferralSource { get; set; }
        public ICollection<ReferralSourceModel> Clients { get; set; }
    }
}