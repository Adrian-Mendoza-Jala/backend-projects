using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using CoffeShop.Models;
using CoffeShop.Services;
using QuestPDF.Fluent;

namespace CoffeShop.ViewModels;
public class PageViewModel : INotifyPropertyChanged
{
    private const string filePath = "Customers.pdf";
    private List<Customer> _customers = new List<Customer>()
    {
        new Customer() { FirstName = "Bob", LastName = "Mars", Age = 22, City = "London" },
        new Customer() { FirstName = "Mary", LastName = "Narlic", Age = 33, City = "New York" },
        new Customer() { FirstName = "Peter", LastName = "Patt", Age = 44, City = "Paris" },
        new Customer() { FirstName = "Paul", LastName = "Pearson", Age = 55, City = "Mumbai" },
        new Customer() { FirstName = "Sam", LastName = "Sanchez", Age = 66, City = "Tokyo" },
    };

    private CustomerItemViewModel? _selectedCustomer;
    private readonly IReport<List<Customer>> _employeeReport;

    public PageViewModel(IReport<List<Customer>> employeeReport)
    {
        QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
        foreach (var customer in _customers)
        {
            Customers.Add(new CustomerItemViewModel(customer));
        }

        _employeeReport = employeeReport;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<CustomerItemViewModel> Customers { get; set; } = new();

    public void Add()
    {
        var customer = new Customer()
        {
            FirstName = "New",
            LastName = "Customer",
            Age = 0,
            City = "City"
        };

        var customerItemViewModel = new CustomerItemViewModel(customer);
        Customers.Add(customerItemViewModel);
        SelectedCustomer = customerItemViewModel;
    }

    public async Task GeneratePDF(CancellationToken cancellationToken)
    {
        _employeeReport.SetData(_customers);
        var task = Task.Run(() =>
        {
            Thread.Sleep(4000);
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            _employeeReport.GeneratePdf(filePath);
            Process.Start("explorer.exe", filePath);
        }, cancellationToken);
        await task;
    }

    public void SaveChanges()
    {
        _customers = Customers.Select(x => new Customer
        {
            Age = x.Age,
            City = x.City,
            FirstName = x.FirstName,
            LastName = x.LastName
        }).ToList();
    }

    public CustomerItemViewModel? SelectedCustomer
    {
        get => _selectedCustomer;
        set
        {
            if (value != _selectedCustomer)
            {
                _selectedCustomer = value;
                RaisePropertyChanged(nameof(SelectedCustomer));
            }
        }
    }

    public Action<object?, PropertyChangedEventArgs>? UnsavedChangesMessage { get; internal set; }

    private void RaisePropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        if (_selectedCustomer is not null && UnsavedChangesMessage is not null)
        {
            _selectedCustomer.PropertyChanged -= UnsavedChangesMessage.Invoke;
            _selectedCustomer.PropertyChanged += UnsavedChangesMessage.Invoke;
        }
    }

    public void Delete()
    {
        if (SelectedCustomer != null)
        {
            Customers.Remove(SelectedCustomer);
        }
    }
}
