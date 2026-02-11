using MauiApp1.Models;
using System.Windows.Input;
using MauiApp1.Services;

namespace MauiApp1.ViewModels
{
    public class EditPageViewModel
    {
        public Listing Order { get; set; }
        public ICommand SaveCommand { get; }

        public EditPageViewModel(Listing order)
        {
            Order = order;
            SaveCommand = new Command(Save);
        }

        private void Save()
        {
            var data = FileService.Betoltes();
            var existing = data.Orders.FirstOrDefault(o => o.Name == Order.Name);
            if (existing != null)
            {
                existing.Quantity = Order.Quantity;
                existing.Price = Order.Price;
                existing.SalePrice = Order.SalePrice;
                FileService.Mentes(data);
            }
        }
    }
}