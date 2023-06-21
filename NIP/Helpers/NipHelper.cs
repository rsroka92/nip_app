using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.Helpers
{
    public static class NipHelper
    {
        public static bool ValidateNip(string nip)
        {
            if (nip.Length != 10 || nip.Any(chr => !Char.IsDigit(chr)))
                return false;

            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7, 0 };
            int sum = nip.Zip(weights, (digit, weight) => (digit - '0') * weight).Sum();

            return (sum % 11) == (nip[9] - '0');
        }

        public static string TrimDash(string nip)
        {
            return nip.Replace("-", string.Empty);
        }
    }
}
