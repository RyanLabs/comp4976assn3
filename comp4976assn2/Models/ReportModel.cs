using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models
{
    public class ReportModel
    {
        public int Open { get; set; }
        public int Closed { get; set; }
        public int Reopened { get; set; }
        public int Crisis { get; set; }
        public int Court { get; set; }
        public int SMART { get; set; }
        public int DVU { get; set; }
        public int MCFD { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }
        public int Trans { get; set; }
        public int Adult { get; set; }
        public int Youth18 { get; set; }
        public int Youth12 { get; set; }
        public int Child { get; set; }
        public int Senior { get; set; }

    }
}