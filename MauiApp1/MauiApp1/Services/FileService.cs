using MauiApp1.Models;
using System.Globalization;

namespace MauiApp1.Services
{
    public class FileService
    {
        private static readonly string ProductsFile =
            Path.Combine(AppContext.BaseDirectory, "C:\\Users\\b1harbal\\Source\\Repos\\ccukorka_maui\\MauiApp1\\MauiApp1\\candy.csv");
        private static readonly string OrdersFile =
            Path.Combine(AppContext.BaseDirectory, "C:\\Users\\b1harbal\\Source\\Repos\\ccukorka_maui\\MauiApp1\\MauiApp1\\reports.csv");

        public static Data Betoltes()
        {
            var data = new Data();

            if (File.Exists(ProductsFile))
            {
                var productLines = File.ReadAllLines(ProductsFile);
                List<Candy> products = new();
                foreach (var line in productLines.Skip(1))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var values = line.Split(',');
                    if (values.Length >= 3)
                    {
                        products.Add(new Candy
                        {
                            Name = values[0],
                            Price = double.Parse(values[1], CultureInfo.InvariantCulture),
                            Quantity = int.Parse(values[2])
                        });
                    }
                }
                data.Products = products;
            }
            else
            {
                data.Products = new List<Candy>();
            }

            if (File.Exists(OrdersFile))
            {
                var orderLines = File.ReadAllLines(OrdersFile);
                List<Listing> orders = new();
                foreach (var line in orderLines.Skip(1))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var values = line.Split(',');
                    if (values.Length >= 4)
                    {
                        orders.Add(new Listing
                        {
                            Name = values[0],
                            Quantity = int.Parse(values[1]),
                            Price = int.Parse(values[2]),
                            SalePrice = double.Parse(values[3], CultureInfo.InvariantCulture)
                        });
                    }
                }
                data.Orders = orders;
            }
            else
            {
                data.Orders = new List<Listing>();
            }

            return data;
        }

        public static void Mentes(Data adat)
        {
            var productLines = new List<string> { "Name,Price,Quantity" };
            foreach (var candy in adat.Products)
            {
                productLines.Add($"{candy.Name},{candy.Price.ToString(CultureInfo.InvariantCulture)},{candy.Quantity}");
            }
            File.WriteAllLines(ProductsFile, productLines);

            var orderLines = new List<string> { "Name,Quantity,Price,SalePrice" };
            foreach (var order in adat.Orders)
            {
                orderLines.Add($"{order.Name},{order.Quantity},{order.Price},{order.SalePrice.ToString(CultureInfo.InvariantCulture)}");
            }
            File.WriteAllLines(OrdersFile, orderLines);
        }
    }
}
