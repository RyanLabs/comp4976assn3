using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class CrisisModel
    {
        [Key]
        public int CrisisId { get; set; }
        public String Crisis { get; set; }
        public List<ClientModel> Client { get; set; }
    }
}