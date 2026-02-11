using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ReportPage : ContentPage
{
	public ReportPage()
	{
		InitializeComponent();
        BindingContext = new ReportPageViewModel();
    }
}