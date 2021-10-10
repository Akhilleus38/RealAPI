using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;


namespace RealAPI.Models.Product
{
   
    public class BranchDetailModel
    {
        public int? branchId { get; set; }
        public string branchName { get; set; }
        public decimal? price { get; set; }
        public decimal? campaignPrice { get; set; }
        public decimal? quantity { get; set; }
        public DateTime? campaignEndDate { get; set; }
    }

    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int? id { get; set; }
        public int? categoryId { get; set; }
        public string categoryName { get; set; }
        public int? subCategoryId { get; set; }
        public string subCategoryName { get; set; }
        public int? vatRateId { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string unitTypeName { get; set; }
        public int? unitTypeId { get; set; }
        public string description { get; set; }
        public decimal? vatRate { get; set; }
        public bool isFavorite { get; set; }
        public decimal? quantityStep { get; set; }
        private double? _cartQuantity;
        [JsonProperty("cartQuantity")]
        public double? CartQuantity
        {
            get { return _cartQuantity; }
            set { _cartQuantity = value;  OnPropertyChanged("cartImage"); }
        }
        public string cartImage
        {
            get
            {
                if (CartQuantity == 0) 
                {
                    
                    return "Plus.png";
                }
                else
                {
                    return "Minuse.png";
                }
            }

        }
        public DateTime createDate { get; set; }
        public List<string> images { get; set; }
        public Uri image => new Uri(images.FirstOrDefault().Replace("http", "https"));
        public byte[] imageBytes
        {
            get
            {
                var httpClient = new HttpClient();
                return httpClient.GetByteArrayAsync(image).Result;
            }
        }
        public List<BranchDetailModel> branchDetailModel { get; set; }
    }

    public class ProductResponseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public List<Item> items { get; set; }
        public int? currentPage { get; set; }
        public int? totalCount { get; set; }
        public bool success { get; set; }
        public List<string> messages { get; set; }
    }
    public class ProductRequestModel
    {

        public int branchId { get; set; }
        public int page { get; set; }
    }
}
