using System.ComponentModel;
using CoffeShop.Models;

namespace CoffeShop.ViewModels;
public class CustomerItemViewModel : INotifyPropertyChanged
{
    private readonly Customer _model;

    public CustomerItemViewModel(Customer model)
    {
        _model = model;
    }

    public string? City
    {
        get => _model.City;
        set
        {
            if (_model.City != value)
            {
                _model.City = value;
                RaisePropertyChanged(nameof(City));
            }
        }
    }

    public int Age
    {
        get => _model.Age;
        set
        {
            if (_model.Age != value)
            {
                _model.Age = value;
                RaisePropertyChanged(nameof(Age));
            }
        }
    }

    public string LastName
    {
        get => _model.LastName;
        set
        {
            if (_model.LastName != value)
            {
                _model.LastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }
    }

    public string FirstName
    {
        get => _model.FirstName;
        set
        {
            if (_model.FirstName != value)
            {
                _model.FirstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
