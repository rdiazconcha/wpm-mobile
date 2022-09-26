using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using WisdomPetMedicine.DataAccess;
using WisdomPetMedicine.Services;
using WisdomPetMedicine.Views;

namespace WisdomPetMedicine.ViewModels;

public class ProductsViewModel : ViewModelBase
{
    private readonly WpmDbContext dbContext;
	private readonly INavigationService navigationService;
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

	public ProductsViewModel(INavigationService navigationService)
	{
		//dbContext = new WpmDbContext();
		//dbContext.Categories.Load();
		//Products = new ObservableCollection<Product>(dbContext.Products.ToImmutableList());
		//dbContext.Dispose();
		//PropertyChanged += ProductsViewModel_PropertyChanged;
		//this.navigationService = navigationService;
	}

	private async void ProductsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(SelectedProduct))
		{
            var uri = $"{nameof(ProductDetailsPage)}?id={SelectedProduct.Id}";
            await navigationService.GoToAsync(uri);
        }
	}
}