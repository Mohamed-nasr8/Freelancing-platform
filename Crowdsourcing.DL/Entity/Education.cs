using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Entity
{
    public class Education
    {
        public int Id { get; set; }
        public string School { get; set; }
        public string Degree { get; set; }
        public string FeildOfStudy { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }


    }
}