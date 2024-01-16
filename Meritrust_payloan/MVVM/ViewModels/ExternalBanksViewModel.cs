using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MeriTrust_MAUI.MVVM.Models;
using System.Text.Json;


namespace MeriTrust_MAUI.MVVM.ViewModels
{
    public class ExternalBanksViewModel:ObservableObject
    {
        private ObservableCollection<ExternalBanks> _externalbankComp;
        public ObservableCollection<ExternalBanks> externalbanksComp
        {
            get { return _externalbankComp; }
            set { SetProperty(ref _externalbankComp, value); }
        }


        HttpClient client;
        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://golden-internally-doe.ngrok-free.app/";

        public ExternalBanksViewModel()
        {
            client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            externalbanksComp = new ObservableCollection<ExternalBanks>();
            _ = GetSelectionComponentsAsync();
        }

        public async Task GetSelectionComponentsAsync()
        {
            var uri = new Uri(string.Format(baseUrl + "ExternalBank", string.Empty));
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                List<ExternalBanks> externalbankComps = ParseJsonManually(content);
                foreach (var comp in externalbankComps)
                {
                    externalbanksComp.Add(comp);
                }
                Console.WriteLine("Success:", externalbanksComp);
            }
        }

        private List<ExternalBanks> ParseJsonManually(string json)
        {
            List<ExternalBanks> payloanComps = new List<ExternalBanks>();
            JsonDocument jsonDocument = JsonDocument.Parse(json);
            foreach (JsonElement element in jsonDocument.RootElement.EnumerateArray())
            {
                ExternalBanks selectionComp = new ExternalBanks
                {
                    id = element.GetProperty("Id").GetInt32(),
                    bankname = element.GetProperty("bankname").GetString(),
                    accountnumber = element.GetProperty("accountnumber").GetString(),
                    account_type = element.GetProperty("account_type").GetString(),
                    addDate = element.GetProperty("addDate").GetString(),
                    bankstatus = element.GetProperty("bankstatus").GetString(),
                    banknamenumber = element.GetProperty("bankname").GetString()+" - "+ element.GetProperty("accountnumber").GetString()
                };
                payloanComps.Add(selectionComp);
            }

            return payloanComps;
        }
    }
}
