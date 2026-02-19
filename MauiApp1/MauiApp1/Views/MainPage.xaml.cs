using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var selectedOrder = button?.CommandParameter as Listing;

            if (selectedOrder != null)
            {
                await Navigation.PushAsync(new EditPage(selectedOrder));
            }
        }

    }
}
