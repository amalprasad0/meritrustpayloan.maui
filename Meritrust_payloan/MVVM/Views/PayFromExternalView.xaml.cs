using MeriTrust_MAUI.MVVM.Models;
using MeriTrust_MAUI.MVVM.ViewModels;

namespace MeriTrust_MAUI.MVVM.Views;

public partial class PayFromExternalView : ContentPage
{
    string toBankName;
    string toAccountNumber;
    string details;
    string fromAccountNumber;
    string fromBankName;
    public PayFromExternalView()
	{
		InitializeComponent();
	}
    public PayFromExternalView(string Details)
    {
        InitializeComponent();
        BindingContext = new ExternalBanksViewModel();
        details = Details;
        
        Console.WriteLine("Details: " + details);
        string[] parts = details.Split('-');
        if (parts.Length == 2)
        {
            fromBankName = parts[0].Trim();
            fromAccountNumber = parts[1].Trim();
            Console.WriteLine("From Bank Name: " + fromBankName);
            Console.WriteLine("From Account Number: " + fromAccountNumber);
        }
        Title.Text = "Pay from " + fromBankName;
    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime paydate = e.NewDate;
        string date = paydate.ToString("d");
        Console.WriteLine("Selected Date: " + date);
    }

    private void payToBank(object sender, EventArgs e)
    {
        var selectedBank = (ExternalBanks)payfrom.SelectedItem;
        if (selectedBank != null)
        {
            toBankName = selectedBank.banknamenumber;
            Console.WriteLine("Selected Bank: " + toBankName);
            string[] parts = toBankName.Split('-');
            if (parts.Length == 2)
            {
                toAccountNumber = parts[1].Trim();
                Console.WriteLine("Account Number: " + toAccountNumber);
            }
        }
    }

    private void onSubmit(object sender, EventArgs e)
    {
        List<string> Details = new List<string>();
        Details.Add(fromBankName);
        Details.Add(toBankName);
        Details.Add(fromAccountNumber);
        Details.Add(toAccountNumber);
        DateTime selectedDate = paydate.Date;
        string payDate = selectedDate.ToString("d");
        Details.Add(payDate);
        Details.Add(Amount.Text);
        Navigation.PushAsync(new PaymentConfirmationView(Details));
    }
}