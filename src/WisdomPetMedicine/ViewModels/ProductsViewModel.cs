using System.Collections.ObjectModel;
using WisdomPetMedicine.DataAccess;

namespace WisdomPetMedicine.ViewModels;
internal class ProductsViewModel : ViewModelBase
{
	private ObservableCollection<Product> products;

	public ObservableCollection<Product> Products
	{
		get { return products; }
		set { products = value;
			RaisePropertyChanged();
		}
	}

	private Product selectedProduct;

	public Product SelectedProduct
	{
		get { return selectedProduct; }
		set { selectedProduct = value;
			RaisePropertyChanged();
		}
	}

	public ProductsViewModel()
	{
		var dbContext = new WpmDbContext();
		Products = new ObservableCollection<Product>(dbContext.Products);
	}

}