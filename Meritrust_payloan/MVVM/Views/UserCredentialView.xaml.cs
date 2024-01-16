using MeriTrust_MAUI.MVVM.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace MeriTrust_MAUI.MVVM.Views;

public partial class UserCredentialView : ContentPage
{
    string bankname;
    string banklogo;
    private readonly HttpClient _httpClient;

    public UserCredentialView()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
    }

    public UserCredentialView(List<string> Details)
    {
        InitializeComponent();
        bankname = Details[0];
        banklogo = Details[1];
        Console.WriteLine("Bank Name: " + bankname);
        bankimg.Source = banklogo;
        bankStamp.Text = bankname;
    }

    private async void OnSubmit(object sender, EventArgs e)
    {
        string username = Username.Text;
        string password = Password.Text;
        Console.WriteLine("Username: " + username);
        Console.WriteLine("Password: " + password);
       await GetSelectionComponentsAsync(username, password);
    }
    public async Task GetSelectionComponentsAsync(string username, string password)
    {
        List<UserBank_Comp> payloanComp = new List<UserBank_Comp>();
        var client = new HttpClient();
        string baseUrl =
            $"https://golden-internally-doe.ngrok-free.app/UserBank?username={username}&userpassword={password}";
        var uri = new Uri(string.Format(baseUrl, string.Empty));
        var response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine();
            List<UserBank_Comp> userList = JsonConvert.DeserializeObject<List<UserBank_Comp>>(
                content
            );

            string userName = userList[0].username;
            string userPassword = userList[0].userpassword;
            string bankName = userList[0].bankname;
            string accountNumber = userList[0].accountnumber;
            string bankStatus = userList[0].bankstatus;
            string accountType = userList[0].accounttype;
            string addDate = userList[0].AddDate;
          
            OnSubmitData(userName, userPassword, bankName, accountNumber, bankStatus, accountType, addDate);
           
        }
        else
        {
            Console.WriteLine("error");
            DisplayAlert("Sorry", "not Found", "OK");
        }
    }
    private async void OnSubmitData(string userName,string userPassword,string bankName,string accountnumber,string bankStatus,string accountType,string adddate)
    {

        HttpClient client = new HttpClient();
        Dictionary<string, string> data = new Dictionary<string, string>
        {
            {"bankname",bankName },
            { "accountnumber", accountnumber },
            { "account_type", accountType },
            { "AddDate", adddate },
            { "bankstatus", bankStatus }
           
        };
        string json = JsonConvert.SerializeObject(data);
        string url = "https://golden-internally-doe.ngrok-free.app/AddUserBank/InsertBank";
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Success", "Login Successfull-"+bankName, "OK");
                await Task.Delay(1000);
                Navigation.PushAsync(new ManageView());
            }
            else
            {
                DisplayAlert("Unsuccessful", "Your request is unsuccessful", "OK");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"{ex.Message.ToString()}", "OK");
        }
        finally
        {
            client.Dispose();
        }
    }
}
