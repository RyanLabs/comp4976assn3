using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class DuplicateFileModel
    {
        [Key]
        public int DuplicateFileId { get; set; }
        public String DuplicateFile { get; set; }
        public ICollection<DuplicateFileModel> Clients { get; set; }
    }
}