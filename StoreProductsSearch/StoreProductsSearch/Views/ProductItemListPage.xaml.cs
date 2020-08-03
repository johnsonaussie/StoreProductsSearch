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
    public partial class ProductItemListPage : ContentPage
    {
        public ProductItemListPage()
        {
           InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //string mystring = Constants.SpecialFolder;
            //databasepath = Constants.DatabasePath;
            //ProductItemDatabase DataBase;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnSearchClicked(object sender, EventArgs e)
        {
            if (SearchItem.Text != "")
            {
                listView.ItemsSource = await App.Database.GetItemsSearch(SearchItem.Text);
            }

        }
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync
            (
                new ProductItemPage {BindingContext = new ProductItem()}
            );
        }
       
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ProductItemPage
                {
                    BindingContext = e.SelectedItem as ProductItem
                });
            }
        }
    }
}
