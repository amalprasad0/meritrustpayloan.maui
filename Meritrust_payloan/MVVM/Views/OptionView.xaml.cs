using MeriTrust_MAUI.MVVM.ViewModels;

namespace MeriTrust_MAUI.MVVM.Views;

public partial class OptionView : ContentPage
{
	public OptionView()
	{
		InitializeComponent();
		BindingContext = new OptionViewModel();
	}

    private void OnNavigateTo(object sender, TappedEventArgs e)
    {
       var screenRoute = (e.Parameter) as string;
       switch (screenRoute)
        {
            case "ScheduledView":
                Navigation.PushAsync(new ScheduledView());
                break;
            case "ManageView":
                Navigation.PushAsync(new ManageView());
                break;
            case "PaymentView":
                Navigation.PushAsync(new PaymentOptionView());
                break;
            default:
                break;
        }
    }
}