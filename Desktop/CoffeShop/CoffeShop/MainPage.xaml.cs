using System.ComponentModel;
using System.Threading;
using CoffeShop.ViewModels;
using Microsoft.UI;

namespace CoffeShop;

public sealed partial class MainPage : Page
{
    private CancellationTokenSource _cancellationTokenSource = new();
    private string? _statusMessage;

    public MainPage()
    {
        this.InitializeComponent();
        var container = ((App)App.Current).Container;
        this.ViewModel = (PageViewModel)ActivatorUtilities
            .GetServiceOrCreateInstance(container, typeof(PageViewModel));
        root.DataContext = this.ViewModel;
        root.Loaded += Root_Loaded;

        this.ViewModel.UnsavedChangesMessage = SelectedCustomer_PropertyChanged;
    }

    public PageViewModel ViewModel { get; }

    private void ThemeToggleButton_Clicked(object sender, RoutedEventArgs e)
    {
        root.RequestedTheme = root.RequestedTheme == ElementTheme.Light 
            ? ElementTheme.Dark
            : ElementTheme.Light;
    }

    private void SelectedCustomer_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        _statusMessage = "*Unsaved Changes";
        UnsavedChangesMessage
            .SetValue(TextBlock.TextProperty, _statusMessage);
        UnsavedChangesMessage
            .SetValue(TextBlock.ForegroundProperty, new SolidColorBrush(Colors.Red));
    }

    private void Root_Loaded(object sender, RoutedEventArgs e)
    {
        //this.ViewModel.LoadData();
    }

    private async void PrintPDF(object sender, RoutedEventArgs e)
    {
        UnsavedChangesMessage.SetValue(TextBlock.TextProperty, "Generating PDF...");
        await ViewModel.GeneratePDF(_cancellationTokenSource.Token);

        UnsavedChangesMessage.SetValue(TextBlock.TextProperty, _statusMessage);
        ResetCancellation();
    }

    private void SaveChanges(object sender, RoutedEventArgs e)
    {
        _statusMessage = "";
        UnsavedChangesMessage.SetValue(TextBlock.TextProperty, _statusMessage);
        ViewModel.SaveChanges();
        ResetCancellation();
    }

    private void Cancel(object sender, RoutedEventArgs e)
    {
        UnsavedChangesMessage.SetValue(TextBlock.TextProperty, "Try cancelling operation...");
        _cancellationTokenSource.Cancel();
    }

    private void ResetCancellation()
    {
        if (!_cancellationTokenSource.TryReset())
        {
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
        }
    }
}
