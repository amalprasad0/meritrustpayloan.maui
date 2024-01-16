using MeriTrust_MAUI.MVVM.ViewModels;

namespace MeriTrust_MAUI.MVVM.Views;

public partial class ManageView : ContentPage
{
    private HttpClient client = new HttpClient();

    public ManageView()
	{
		InitializeComponent();
		BindingContext = new ExternalBanksViewModel();
	}

    private async  void PayFrom(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string parameter = button.CommandParameter as string;
        if (parameter != null)
        {
            Console.WriteLine("parameter: " + parameter);
            await Navigation.PushAsync(new PayFromExternalView(parameter));
        }
    }

    private void GotoBankSearch(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BankSearchView());
    }

    private async void OnDelete(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var id = (int)button.CommandParameter;
        Console.WriteLine("ID: " + id);
        
        if (id != null)
        {
           
            DeleteItemAsync(id);
        }
    }
    private async Task DeleteItemAsync(int id)
    {
        try
        {
            HttpResponseMessage response = await client.DeleteAsync($"https://golden-internally-doe.ngrok-free.app/delete/DeleteExternal?Id={id}");

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Success", "Deleted Successfully", "OK");
                Console.WriteLine("Deleted Successfully", response);
                BindingContext = new ExternalBanksViewModel();

            }
            else
            {
                DisplayAlert("Warning", "Request failed due to internal issues", "OK");
                Console.WriteLine("Error Occured", response);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Occured", ex.Message);
        }
    }
}