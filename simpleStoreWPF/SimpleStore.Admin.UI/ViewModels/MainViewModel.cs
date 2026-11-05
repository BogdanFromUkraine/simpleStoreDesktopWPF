using SimpleStore.Admin.Core.Entities;
using SimpleStore.Admin.Core.Interfaces;
using SimpleStore.Admin.UI.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SimpleStore.Admin.UI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IProductRepository _productRepository;

    public ObservableCollection<Product> Products { get; } = new();

    public ICommand LoadProductsCommand { get; }

    public MainViewModel(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        LoadProductsCommand = new RelayCommand(async _ => await LoadProductsAsync());

        // Автоматично завантажуємо товари при створенні ViewModel
        _ = LoadProductsAsync();
    }

    private async Task LoadProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        Products.Clear();
        foreach (var product in products)
        {
            Products.Add(product);
        }
    }
}