using Newtonsoft.Json;
using RealAPI.Models.Cart;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RealAPI.Services
{
   public static  class CartServices
    
    {
       
        public static async Task<CartResponseModel> GetCartRequest(CartRequestModel CartRequestModel)
        {
            var contentLogin = await ApiServices.ServiceClientInstance.AuthenticateUserAsync("ahmet@gmail.com", "daldal38");
            try
            {

                var content = new StringContent(JsonConvert.SerializeObject(CartRequestModel), Encoding.UTF8, "application/json");
               var requestLogin = $"Bearer {contentLogin.token}";
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://1dilek.com/Cart/addtocart"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", requestLogin);
                        request.Content = content;
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        return JsonConvert.DeserializeObject<CartResponseModel>(await response.Content.ReadAsStringAsync());
                    }
                }
              
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
