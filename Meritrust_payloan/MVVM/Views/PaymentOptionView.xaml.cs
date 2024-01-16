using MeriTrust_MAUI.MVVM.ViewModels;

namespace MeriTrust_MAUI.MVVM.Views;

public partial class PaymentOptionView : ContentPage
{
    public PaymentOptionView()
    {
        InitializeComponent();
        BindingContext = new PaymentOptionViewModel();
    }
    private void OnNavigateTo(object sender, TappedEventArgs e)
    {
        var screenRoute = (e.Parameter) as string;
        switch (screenRoute)
        {
            case "Paybank":
                Navigation.PushAsync(new PayFromBankView());
                break;
            case "Paycard":
                Navigation.PushAsync(new PayFromCredit());
                break;
            default:
                break;

                
        }
    }
}