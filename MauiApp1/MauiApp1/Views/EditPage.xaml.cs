using MauiApp1.Models;
using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class EditPage : ContentPage
{
    private readonly Listing selectedOrder;

    public EditPage(Listing selectedOrder)
    {
        InitializeComponent();
        this.selectedOrder = selectedOrder;
        BindingContext = new EditPageViewModel(this.selectedOrder);
    }
}