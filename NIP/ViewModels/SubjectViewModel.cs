using NIP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.ViewModels
{
    public class SubjectViewModel : Subject
    {
        public List<Representative> representatives { get; set; } = new List<Representative>();
        public List<AccountNumber> accountNumbers { get; set; } = new List<AccountNumber>();
        public List<Partner> partners { get; set; } = new List<Partner>();
    }
}
