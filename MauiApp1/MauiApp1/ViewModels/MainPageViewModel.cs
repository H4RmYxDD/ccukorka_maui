using MauiApp1.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<Candy> Products { get; }

        public MainPageViewModel()
        {
            var data = FileService.Betoltes();
            Products = new ObservableCollection<Candy>(data.Products);
        }
    }
}