using MeriTrust_MAUI.MVVM.ViewModels;

namespace MeriTrust_MAUI.MVVM.Views;

public partial class ScheduledView : ContentPage
{
    private HttpClient client = new HttpClient();

    public ScheduledView()
	{
		InitializeComponent();
		BindingContext = new ScheduledViewModel();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var id = e.Parameter;
		Console.WriteLine("ID: " + id);
        int Id = Convert.ToInt32(id);
        DeleteItemAsync(Id);
    }
    private async Task DeleteItemAsync(int id)
    {
        try
        {
            HttpResponseMessage response = await client.DeleteAsync($"https://golden-internally-doe.ngrok-free.app/delete/delete?Id={id}");

            if (response.IsSuccessStatusCode)
            {
                DisplayAlert("Success", "Deleted Successfully", "OK");
                Console.WriteLine("Deleted Successfully",response);
                BindingContext = new ScheduledViewModel();

            }
            else
            {
                DisplayAlert("Warning", "Request failed due to internal issues", "OK");
                Console.WriteLine("Error Occured",response);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Occured", ex.Message);
        }
    }
}