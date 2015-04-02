using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class RepeatClientModel
    {
        [Key]
        public int RepeatClientId { get; set; }
        public String RepeatClient { get; set; }
        public ICollection<RepeatClientModel> Clients { get; set; }
    }
}