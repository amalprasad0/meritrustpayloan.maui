using MeriTrust_MAUI.MVVM.Models;
using MeriTrust_MAUI.MVVM.ViewModels;

namespace MeriTrust_MAUI.MVVM.Views;

public partial class PayFromCredit : ContentPage
{
    string toBankName;
    string toAccountNumber;
	public PayFromCredit()
	{
		InitializeComponent();
		BindingContext = new ExternalBanksViewModel();
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
        Details.Add("VISAXXXXXXXX459");
        Details.Add(toBankName);
        Details.Add("Credit-Card-No-HIDDEN");
        Details.Add(toAccountNumber);
        DateTime selectedDate = paydate.Date;
        string payDate = selectedDate.ToString("d");
        Details.Add(payDate);
        Details.Add(Amount.Text);
        Navigation.PushAsync(new PaymentConfirmationView(Details));


    }

    private void backToHome(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }
}