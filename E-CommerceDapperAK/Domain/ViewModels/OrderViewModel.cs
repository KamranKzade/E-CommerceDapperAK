using E_CommerceDapperAK.DataAccess.Entities;
using E_CommerceDapperAK.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E_CommerceDapperAK.Domain.ViewModels
{
    public class OrderViewModel:BaseViewModel
    {
		private OrderDetails order;

		public OrderDetails Order
        {
			get { return order; }
			set { order = value; OnPropertyChanged(); }
		}

		private short productQuantity;

		public short ProductQuantity
        {
			get { return productQuantity; }
			set { productQuantity = value;  OnPropertyChanged(); }
		}

		public RelayCommand	SubmitCommand { get; set; }

		public OrderViewModel(Product product)
		{
			Order=new OrderDetails();
			Order.UnitPrice=product.UnitPrice;
			order.ProductID=product.ProductID;
			order.Discount = (new Random()).Next(5, 50);

			ProductQuantity = product.UnitsInStock;

			SubmitCommand = new RelayCommand((o) =>
			{
				App.DB.OrderDetailsRepository.Add(Order);
		        
				product.UnitsInStock -= Order.Quantity;

				App.DB.ProductRepository.Update(product);

				MessageBox.Show("Successfully purchased");
			});
		}

	}
}
