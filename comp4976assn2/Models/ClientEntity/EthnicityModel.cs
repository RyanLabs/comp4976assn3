using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class EthnicityModel
    {
        [Key]
        public int EthnicityId { get; set; }
        public String Ethnicity { get; set; }
        public ICollection<EthnicityModel> Clients { get; set; }
    }
}