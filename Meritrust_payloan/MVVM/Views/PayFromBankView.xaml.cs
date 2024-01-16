using MeriTrust_MAUI.MVVM.Models;
using MeriTrust_MAUI.MVVM.ViewModels;

namespace MeriTrust_MAUI.MVVM.Views;

public partial class PayFromBankView : ContentPage
{
    string fromBankName;
    string toBankName;
    string fromAccountNumber;
    string toAccountNumber;

    public PayFromBankView()
    {
        InitializeComponent();
        BindingContext = new ExternalBanksViewModel();
        //Amount.Text = "10.00";
        Amount.Background = null;
    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        DateTime paydate = e.NewDate;
        string date = paydate.ToString("d");
        Console.WriteLine("Selected Date: " + date);
    }

    private void payFromBank(object sender, EventArgs e)
    {
        var selectedBank = (ExternalBanks)payfrom.SelectedItem;
        if (selectedBank != null)
        {
            fromBankName = selectedBank.banknamenumber;
            Console.WriteLine("Selected Bank: " + fromBankName);
            string[] parts = fromBankName.Split('-');

            if (parts.Length == 2)
            {
                fromAccountNumber = parts[1].Trim();
                Console.WriteLine("Account Number: " + fromAccountNumber);
            }
        }
    }

    private void payToBank(object sender, EventArgs e)
    {
        var selectedBank = (ExternalBanks)payto.SelectedItem;
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

    private void Pay_Clicked(object sender, EventArgs e)
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
        Console.WriteLine("Details: " + Details);
        Navigation.PushAsync(new PaymentConfirmationView(Details));
    }

    private void goToBank(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BankSearchView());
    }
}
