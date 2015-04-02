using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class FileStatusModel
    {
        [Key]
        public int FileStatusId { get; set; }
        public String FileStatus { get; set; }
        public ICollection<FileStatusModel> Clients { get; set; }
    }
}