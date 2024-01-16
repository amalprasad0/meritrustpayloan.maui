using MeriTrust_MAUI.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeriTrust_MAUI.MVVM.ViewModels
{
    public class PaymentOptionViewModel
    {
        public List<PaymentOption_Comp> paymentOptions { get; set; }
        public PaymentOptionViewModel() 
        {
            paymentOptions = new List<PaymentOption_Comp>
            {
                new PaymentOption_Comp { title = "Pay from bank account", screenRoute = "Paybank" },
                new PaymentOption_Comp { title = "Pay from credit card", screenRoute = "Paycard" },
            };
        }
    }
}
