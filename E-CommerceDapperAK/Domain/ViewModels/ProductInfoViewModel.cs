﻿using E_CommerceDapperAK.DataAccess.Entities;
using E_CommerceDapperAK.Domain.Commands;
using E_CommerceDapperAK.Domain.Helpers;
using E_CommerceDapperAK.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDapperAK.Domain.ViewModels
{
    public class ProductInfoViewModel:BaseViewModel
    {
		private Product product;

		public Product Product
		{
			get { return product; }
			set { product = value; OnPropertyChanged(); }
		}

		private string imagePath;

		public string ImagePath
		{
			get { return imagePath; }
			set { imagePath = value; OnPropertyChanged(); }
		}


		public RelayCommand	OrderCommand { get; set; }

		public ProductInfoViewModel(Product product)
		{
			Product = product;
			ImageHelper helper = new ImageHelper();
			var path=helper.GetImagePath(product.Category.Picture,product.CategoryID);
			ImagePath = path;

			OrderCommand = new RelayCommand((o) =>
			{
				var vm = new OrderViewModel(Product);
				var view = new OrderWindow();
				view.DataContext = vm;
				view.Show();
			});


		}

	}
}
