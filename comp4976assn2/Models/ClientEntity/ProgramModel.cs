using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class ProgramModel
    {
        [Key]
        public int ProgramId { get; set; }
        public String Program { get; set; }
        public List<ClientModel> Client { get; set; }
    }
}