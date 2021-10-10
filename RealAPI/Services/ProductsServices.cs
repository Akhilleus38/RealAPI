using Newtonsoft.Json;
using RealAPI.Models.Product;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RealAPI.Services
{
    public static class ProductsServices
    {
        public static async Task<ProductResponseModel> GetProductRequest(ProductRequestModel ProductRequestModel)
        {
            var contentLogin = await ApiServices.ServiceClientInstance.AuthenticateUserAsync("ahmet@gmail.com", "daldal38");
            try
            {

                var content = new StringContent(JsonConvert.SerializeObject(ProductRequestModel), Encoding.UTF8, "application/json");
                var requestLogin = $"Bearer {contentLogin.token}";
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://1dilek.com/Product"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", requestLogin);
                        request.Content = content;
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        var returnModel = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<ProductResponseModel>(returnModel);
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