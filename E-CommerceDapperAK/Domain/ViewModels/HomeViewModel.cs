using E_CommerceDapperAK.DataAccess.Entities;
using E_CommerceDapperAK.Domain.Commands;
using E_CommerceDapperAK.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDapperAK.Domain.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
		private ObservableCollection<Product> allProducts;

		public ObservableCollection<Product> AllProducts
        {
			get { return allProducts; }
			set { allProducts = value; OnPropertyChanged(); }
		}

		private Product selectedProduct;

		public Product SelectedProduct
		{
			get { return selectedProduct; }
			set { selectedProduct = value; OnPropertyChanged(); }
		}

		public RelayCommand	SelectedCommand { get; set; }

		public HomeViewModel()
		{
			var productsFromDb = App.DB.ProductRepository.GetAll();
			AllProducts=new ObservableCollection<Product>(productsFromDb);

			SelectedProduct = new Product();

			SelectedCommand = new RelayCommand((o) =>
			{
				ProductInfoViewModel vm = new ProductInfoViewModel(SelectedProduct);
				ProductInfo view = new ProductInfo();
				view.DataContext = vm;
				view.Show();
			});

		}

	}
}
