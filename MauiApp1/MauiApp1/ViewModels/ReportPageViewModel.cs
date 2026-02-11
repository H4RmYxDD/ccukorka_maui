using MauiApp1.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels
{
    public class ReportPageViewModel
    {
        public ObservableCollection<Listing> Orders { get; }

        public ReportPageViewModel()
        {
            var data = FileService.Betoltes();
            Orders = new ObservableCollection<Listing>(data.Orders);
        }
    }
}