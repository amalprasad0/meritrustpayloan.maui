using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MeriTrust_MAUI.MVVM.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MeriTrust_MAUI.MVVM.ViewModels
{
    public class ScheduledViewModel: ObservableObject
    {
        private ObservableCollection<PayLoanDetails> _payloanComp;
        public ObservableCollection<PayLoanDetails> payloanComp
        {
            get { return _payloanComp; }
            set { SetProperty(ref _payloanComp, value); }
        }
       

        HttpClient client;
        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://golden-internally-doe.ngrok-free.app/";

        public ScheduledViewModel()
        {
            client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            payloanComp = new ObservableCollection<PayLoanDetails>();
            _ = GetSelectionComponentsAsync();
        }

        public async Task GetSelectionComponentsAsync()
        {
            var uri = new Uri(string.Format(baseUrl + "LoanPayment", string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                List<PayLoanDetails> payloanComps = ParseJsonManually(content);
                foreach (var comp in payloanComps)
                {
                    payloanComp.Add(comp);
                }
                Console.WriteLine("Success:", payloanComp);
            }
        }

        private List<PayLoanDetails> ParseJsonManually(string json)
        {
            List<PayLoanDetails> payloanComps = new List<PayLoanDetails>();
            JsonDocument jsonDocument = JsonDocument.Parse(json);
            foreach (JsonElement element in jsonDocument.RootElement.EnumerateArray())
            {
                PayLoanDetails selectionComp = new PayLoanDetails
                {
                    id = element.GetProperty("Id").GetInt32(),
                    FromBankName = element.GetProperty("FromBankName").GetString(),
                    ToBankName = element.GetProperty("ToBankName").GetString(),
                    FromAccountNumber = element.GetProperty("FromAccountNumber").GetString(),
                    ToAccountNumber = element.GetProperty("ToAccountNumber").GetString(),
                    Amount = element.GetProperty("Amount").GetString(),
                    Date = element.GetProperty("PayDate").GetString(),
                    Status = element.GetProperty("LoanStatus").GetString(),
                };
                payloanComps.Add(selectionComp);
            }

            return payloanComps;
        }
    }
}
