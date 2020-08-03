using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreProductsSearch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductItemPage : ContentPage
    {
        public ProductItemPage()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var productItem = (ProductItem)BindingContext;
            await App.Database.SaveItemAsync(productItem);
            await Navigation.PopAsync();
        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var productItem = (ProductItem)BindingContext;
            await App.Database.DeleteItemAsync(productItem);
            await Navigation.PopAsync();
        }
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}