using MauiApp1.Models;
using MauiApp1.Services;
using System.ComponentModel;
using System.Windows.Input;

public class CreatePageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private Listing _order = new Listing();
    public Listing Order
    {
        get => _order;
        set
        {
            _order = value;
            OnPropertyChanged(nameof(Order));
        }
    }

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
