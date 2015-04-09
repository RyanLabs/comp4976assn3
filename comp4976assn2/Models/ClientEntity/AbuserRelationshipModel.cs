using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class AbuserRelationshipModel
    {
        [Key]
        public int AbuserRelationshipId { get; set; }
        public String AbuserRelationship { get; set; }
        public List<ClientModel> Client { get; set; }
    }
}