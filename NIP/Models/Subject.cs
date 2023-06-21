using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.Models
{
    public class Subject
    {
        [Key]
        public string nip { get; set; }
        public string name { get; set; }
        public string pesel { get; set; }
        public string krs { get; set; }
        public string statusvat { get; set; }
        public string regon { get; set; }
        public string residenceaddress { get; set; }
        public string workingaddress { get; set; }
        public DateTime? registrationlegaldate { get; set; }
        public DateTime? registrationdenialdate { get; set; }
        public string registrationdenialbasis { get; set; }
        public DateTime? restorationdate { get; set; }
        public string restorationbasis { get; set; }
        public string removalbasis { get; set; }
        public DateTime? removaldate { get; set; }
        public bool hasvirtualaccounts { get; set; }
        public string requestid { get; set; }
        public string requestdatetime { get; set; }
    }
}
