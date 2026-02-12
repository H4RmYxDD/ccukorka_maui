using MauiApp1.Models;
using MauiApp1.Services;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public class CreateCandyViewModel
    {
        private readonly CandyService _candyService;

        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public ICommand CreateCandyCommand { get; }

        public CreateCandyViewModel()
        {
            var data = FileService.Betoltes();
            _candyService = new CandyService(data.Products, data.Orders);

            CreateCandyCommand = new Command(CreateCandy);
        }

        private void CreateCandy()
        {
            var newCandy = new Candy
            {
                Name = Name,
                Price = Price,
                Quantity = Quantity
            };

            _candyService.Hozzaad(newCandy);

            var data = FileService.Betoltes();
            data.Products = _candyService.Osszes();
            FileService.Mentes(data);
        }
    }
}
