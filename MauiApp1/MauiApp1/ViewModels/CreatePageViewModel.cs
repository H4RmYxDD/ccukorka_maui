using MauiApp1.Models;
using System.Windows.Input;
using MauiApp1.Services;

namespace MauiApp1.ViewModels
{
    public class CreatePageViewModel
    {
        public Listing Order { get; set; } = new Listing { Name = "", Quantity = 0, Price = 0, SalePrice = 0.0 };
        public ICommand CreateCommand { get; }

        public CreatePageViewModel()
        {
            CreateCommand = new Command(Create);
        }

        private void Create()
        {
            var data = FileService.Betoltes();
            data.Orders.Add(Order);
            FileService.Mentes(data);
        }
    }
}