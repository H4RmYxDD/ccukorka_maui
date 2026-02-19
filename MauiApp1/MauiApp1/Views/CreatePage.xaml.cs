using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class CreatePage : ContentPage
{
	public CreatePage()
	{
		InitializeComponent();
        BindingContext = new CreatePageViewModel();
    }
}