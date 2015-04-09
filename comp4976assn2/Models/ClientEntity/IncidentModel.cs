using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class IncidentModel
    {
        [Key]
        public int IncidentId { get; set; }
        public String Incident { get; set; }
        public List<ClientModel> Client { get; set; }
    }
}