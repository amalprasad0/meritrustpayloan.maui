
using Newtonsoft.Json;
using System.Text;

namespace MeriTrust_MAUI.MVVM.Views;

public partial class PaymentConfirmationView : ContentPage
{  
    bool ischecked = false;
    string FromBankName;
    string ToBankName;
    string FromAccountNumber;
    string ToAccountNumber;
    string payonDate;
    string Amount;
	public PaymentConfirmationView()
	{
		InitializeComponent();
	}
    public PaymentConfirmationView(List<string> Details)
    {
        InitializeComponent();
        toBankname.Text = Details[1];
        fromBankname.Text = Details[0];
        payon.Text = Details[4];
        amount.Text = "$" + Details[5];
        int totalamount = Convert.ToInt32(Details[5])+4;
        total.Text = "$" + totalamount.ToString();
        FromBankName = Details[0];
        ToBankName = Details[1];
        FromAccountNumber = Details[2];
        ToAccountNumber = Details[3];
        payonDate = Details[4];
        Amount = totalamount.ToString();

    }

    private void CheckBoxChanged(object sender, CheckedChangedEventArgs e)
    {
        ischecked = e.Value;
    }

    private async void  OnSubmitData(object sender, EventArgs e)
    {
       
        if (!ischecked)
        {
            DisplayAlert("Warning", "Some thing you missed !", "Ok");
            return;
        }
        HttpClient client = new HttpClient();
        Dictionary<string, string> data = new Dictionary<string, string>
        {
            { "FromBankName", FromBankName },
            { "ToBankName", ToBankName },
            { "FromAccountNumber", FromAccountNumber },
            { "ToAccountNumber", ToAccountNumber },
            { "Amount", Amount },
            { "PayDate", payonDate },
            {"LoanStatus","initiated"}
        };
        string json = JsonConvert.SerializeObject(data);
        string url = "https://golden-internally-doe.ngrok-free.app/api/values";
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        try
        {
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                List<String> Details = new List<string>();
                Details.Add(FromBankName);
                Details.Add(ToBankName);
                Details.Add(FromAccountNumber);
                Details.Add(ToAccountNumber);
                Details.Add(payonDate);
                Details.Add(Amount);
                await Task.Delay(1000);
                await Navigation.PushAsync(new PaymentDetailsView(Details));
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