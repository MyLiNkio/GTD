using GTD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTD
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductsPage : ContentPage
	{
		public ProductsPage()
		{
			BindingContext = new ProductsViewModel(Global.RepositoryHolder.GetRepository<Product>());
			InitializeComponent();
		}
	}
}