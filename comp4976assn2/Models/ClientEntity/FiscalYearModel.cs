using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.ClientEntity
{
    public class FiscalYearModel
    {
        [Key]
        [DisplayName("Fiscal Year")]
        public int FiscalId { get; set; }

        [DisplayName("Fiscal Year")]
        public String FiscalYear { get; set; }

        public ICollection<FiscalYearModel> Clients { get; set; }
    }
}