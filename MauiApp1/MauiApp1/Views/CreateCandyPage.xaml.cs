using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class CreateCandyPage : ContentPage
{
    public CreateCandyPage()
    {
        InitializeComponent();
        BindingContext = new CreateCandyViewModel();
    }
}
