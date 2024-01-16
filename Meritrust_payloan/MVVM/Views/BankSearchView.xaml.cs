using MeriTrust_MAUI.MVVM.Models;
using MeriTrust_MAUI.MVVM.ViewModels;

namespace MeriTrust_MAUI.MVVM.Views;

public partial class BankSearchView : ContentPage
{
    public BankSearchView()
    {
        InitializeComponent();
        BindingContext = new BankSearchViewModel();
    }

    private void PassToUser(object sender, EventArgs e)
    {
        var parameter = ((TappedEventArgs)e).Parameter;
        string bankName;
        string bankLogo;

        if (parameter is Bank_Comp viewModel)
        {
             bankName = viewModel.bankname as string;
             bankLogo = viewModel.banklogo as string;
             List<string> Details = new List<string>();
            Details.Add(bankName);
            Details.Add(bankLogo);
            Navigation.PushAsync(new UserCredentialView(Details));
        }
        
    }
}
