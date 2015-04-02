using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class ServiceModel
    {
        [Key]
        public int ServiceId { get; set; }
        public String Service { get; set; }
        public ICollection<ServiceModel> Clients { get; set; }
    }
}