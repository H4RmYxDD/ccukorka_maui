using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class EditPage : ContentPage
{
    public EditPage(Listing selectedOrder)
    {
        InitializeComponent();
        BindingContext = new EditPageViewModel(selectedOrder);
    }
}
