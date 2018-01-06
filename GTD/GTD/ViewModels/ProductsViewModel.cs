using GTD.Models;
using GTD.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GTD
{
	public class ProductsViewModel : INotifyPropertyChanged
	{
		private readonly IRepository<Product> _repository;
		private IEnumerable<Product> _products;

		public IEnumerable<Product> Products
		{
			get { return _products; }
			set { _products = value; OnPropertyChanged(); }
		}


		public double ProductPrice { get; set; }

		public string ProductTitle { get; set; }

		public ICommand RefreshCommand
		{
			get {
				return new Command(async () =>
				  {
					  Products = await _repository.GetAsync();
				  });
			}
		}

		public ICommand AddCommand
		{
			get
			{
				return new Command(async () =>
				{
					var product = new Product { Title = ProductTitle, Price = ProductPrice };
					await _repository.AddAsync(product);
				});
			}
		}

		public ProductsViewModel(IRepository<Product> repository)
		{
			_repository = repository;
			_products = _repository.GetAsync().Result;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
