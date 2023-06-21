using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.Models
{
    public class Partner
    {
        public int id { get; set; }
        public string companyname { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string subjectnip { get; set; }
        public string pesel { get; set; }
        public string nip { get; set; }
    }
}
