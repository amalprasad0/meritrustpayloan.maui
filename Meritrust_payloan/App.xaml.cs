using MeriTrust_MAUI.MVVM.Views;

namespace Meritrust_payloan
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navPage = new NavigationPage(new OptionView());
            navPage.BarBackgroundColor = Color.FromArgb("#549BB9");
            navPage.BarTextColor = Color.FromArgb("#dfe9f3");
            MainPage = navPage;
        }
    }
}
