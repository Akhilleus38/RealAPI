using RealAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealAPI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e) 
        {

            var content = await ApiServices.ServiceClientInstance.AuthenticateUserAsync(MyUserName.Text, MyUserPassword.Text);

            if (!string.IsNullOrEmpty(content.token))
            {
                await Navigation.PushAsync(new DashBoardPage());
            }
            else
            {
               await App.Current.MainPage.DisplayAlert("Uyarı", "Kullanıcı Adı veya Parola Hatalı", "Tamam");
            }
            

        }
        async void Button_Clicked2(System.Object sender, System.EventArgs e)
        {

           
                await Navigation.PushAsync(new Graphics());
            

        }
    }
}
