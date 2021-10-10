 
using Xamarin.Forms; 
using RealAPI.Models.Product;
using RealAPI.Services;
using System;
using Xamarin.Forms.Xaml;
using RealAPI.Models.Cart;

namespace RealAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoardPage : ContentPage
    {
        public DashBoardPage()
        {
            InitializeComponent();

            GetProducts();
        }
        private void CheckoutTap_Tapped(object sender, EventArgs e)
        {

        }
        private async void GetProducts()
        {
            ProductRequestModel searchModel = new ProductRequestModel()
            {

                branchId = 11,
                page = 0,
         
            };
            var productResult = await ProductsServices.GetProductRequest(searchModel);

            ProducstListView.ItemsSource = productResult.items;
        }

        private async void CheckoutTapImage_Tapped(object sender, EventArgs e)
        {

            var image = (StackLayout)sender;
            if (image.GestureRecognizers.Count > 0)
            {
                var tapGesture = (TapGestureRecognizer)image.GestureRecognizers[0];
                var item = (Item)tapGesture.BindingContext;
               
                CartRequestModel cartRequestModel = new CartRequestModel()
                {
                    branchId= 11,
                    productId =item.id.GetValueOrDefault(),
                    quantity=1
                 
                };
                var productResult = await CartServices.GetCartRequest(cartRequestModel);
            }
        }

    }

}
