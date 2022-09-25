using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Services;

namespace WisdomPetMedicine.ViewModels;

internal class ProductsViewModel : ViewModelBase
{
    private readonly WpmDbContext dbContext;

    private ObservableCollection<Product> products;

	public ObservableCollection<Product> Products
	{
		get { return products; }
		set
		{
			products = value;
			RaisePropertyChanged();
		}
	}

	private Product selectedProduct;

	public Product SelectedProduct
	{
		get { return selectedProduct; }
		set
		{
			selectedProduct = value;
			RaisePropertyChanged();
		}
	}

	public ICommand AddCommand { get; set; }


	public ProductsViewModel(INavigationService navigationService)
	{
		dbContext = new WpmDbContext();
		dbContext.Categories.Load();
		AddCommand = new Command(OnAddCommand);
		Products = new ObservableCollection<Product>(dbContext.Products);
	}

	private void OnAddCommand()
	{
		var nextId = dbContext.Products.Max(p => p.Id) + 1;
		dbContext.Products.Add(new Product(nextId, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 100, 1));
		dbContext.SaveChanges();
        Products = new ObservableCollection<Product>(dbContext.Products);
    }
}