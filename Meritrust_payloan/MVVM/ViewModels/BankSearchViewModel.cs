using CommunityToolkit.Mvvm.ComponentModel;

using MeriTrust_MAUI.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeriTrust_MAUI.MVVM.ViewModels
{
    public class BankSearchViewModel : ObservableObject
    {
        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                SetProperty(ref searchText, value);
                Console.WriteLine("SearchText: " + searchText);
                FilteredBankDetails = GetFilteredBankDetails(value);
            }
        }

        private ObservableCollection<Bank_Comp> bankDetails;

        public ObservableCollection<Bank_Comp> BankDetails
        {
            get { return bankDetails; }
            set { SetProperty(ref bankDetails, value); }
        }

        private ObservableCollection<Bank_Comp> filteredBankDetails;

        public ObservableCollection<Bank_Comp> FilteredBankDetails
        {
            get { return filteredBankDetails; }
            set { SetProperty(ref filteredBankDetails, value); }
        }

        public BankSearchViewModel()
        {
            BankDetails = new ObservableCollection<Bank_Comp>
            {
                new Bank_Comp { bankname = "Bank of America", banklogo = "bankamerica.svg" },
                new Bank_Comp { bankname = "Chase Bank of America", banklogo = "chase.svg" },
                new Bank_Comp
                {
                    bankname = "Us Bank National Association",
                    banklogo = "usbank.svg"
                },
                new Bank_Comp { bankname = "PNC Bank of Ameriaca", banklogo = "pncbank.svg" },
                new Bank_Comp { bankname = "Navy Fedral Credit Union", banklogo = "navybank.svg" },
            };
            FilteredBankDetails = BankDetails;
        }

        private ObservableCollection<Bank_Comp> GetFilteredBankDetails(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return BankDetails;
            }
            else
            {
                return new ObservableCollection<Bank_Comp>(
                    BankDetails.Where(
                        bank =>
                            bank.bankname.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                    )
                );
            }
        }
    }
}
