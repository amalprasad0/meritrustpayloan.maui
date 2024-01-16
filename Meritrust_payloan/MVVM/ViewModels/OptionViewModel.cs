using MeriTrust_MAUI.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeriTrust_MAUI.MVVM.ViewModels
{
    public class OptionViewModel
    {
        public List<Option_Comp> Options { get; set; }

        public OptionViewModel()
        {
            Options = new List<Option_Comp> { 
                new Option_Comp { Option = "Scheduled loan payment", screenRoute = "ScheduledView" },
                new Option_Comp { Option = "manage external accounts", screenRoute = "ManageView" },
                new Option_Comp { Option = "make payment", screenRoute = "PaymentView" }, 
            };

        }
    }
}
