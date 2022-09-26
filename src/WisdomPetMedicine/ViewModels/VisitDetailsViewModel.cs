namespace WisdomPetMedicine.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WisdomPetMedicine.DataAccess;

public partial class VisitDetailsViewModel : ViewModelBase, IQueryAttributable
{
    [ObservableProperty]
    int clientId;

    [ObservableProperty]
    private ObservableCollection<Product> products;

    [ObservableProperty]
    private Product selectedProduct;

    [ObservableProperty]
    private int quantity;


    [ObservableProperty]
    private ObservableCollection<Sale> sales = new ObservableCollection<Sale>();

    public ICommand AddCommand { get; set; }

    public VisitDetailsViewModel(WpmOutDbContext dbOut)
    {
        var db = new WpmDbContext();
        Products = new ObservableCollection<Product>(db.Products);
        dbOut.Database.EnsureCreated();

        var allSales = dbOut.Sales.ToList();

        AddCommand = new Command(() =>
        {

            var sale = new Sale(ClientId, SelectedProduct.Id, Quantity, Quantity * SelectedProduct.Price);
            dbOut.Sales.Add(sale);
            dbOut.SaveChanges();
            Sales.Add(sale);
        }, () => true);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ClientId = int.Parse(query["id"].ToString());
    }
}