using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class FamilyViolenceFileModel
    {
        [Key]
        public int FamilyViolenceId { get; set; }
        public String FamilyViolenceFile { get; set; }
        public List<ClientModel> Client { get; set; }
    }
}