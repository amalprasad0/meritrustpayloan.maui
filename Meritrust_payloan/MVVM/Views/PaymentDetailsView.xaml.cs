namespace MeriTrust_MAUI.MVVM.Views;

public partial class PaymentDetailsView : ContentPage
{
    string FromBankName;
    string ToBankName;
    string Amount;
    string payOnDate;
	public PaymentDetailsView()
	{
		InitializeComponent();
	}
    public PaymentDetailsView(List<string> Details)
    {
        InitializeComponent();
        toBankname.Text = Details[1];
        fromBankname.Text = Details[0] +"-"+ Details[2];
        payon.Text = Details[4];
        total.Text = "$" + Details[5];
        int totalamount = Convert.ToInt32(Details[5])-4;
        amount.Text = "$" + totalamount.ToString();
    }

    private void backToHome(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }
}