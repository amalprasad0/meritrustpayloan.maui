using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeriTrust_MAUI.MVVM.Models
{
    public class PayLoanDetails
    {
        public int id { get; set; }
        public string FromBankName { get; set; }
        public string ToBankName { get; set; }
        public string FromAccountNumber { get; set; }
        public string ToAccountNumber { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
    }
}
