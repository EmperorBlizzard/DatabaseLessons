﻿using EM.Models;
using EM.Services;
using System.Collections.ObjectModel;

namespace EM
{
    public partial class MainPage : ContentPage
    {
        private readonly ProductService _productService;
        public ObservableCollection<Product> Products { get; private set; }

        public MainPage(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            Products = new ObservableCollection<Product>();

            GetProducts();
        }

        private async void GetProducts()
        {
            var productList = await _productService.GetProductsAsync();

            if (productList != null)
            {
                Products.Clear();
                foreach (var product in productList)
                    Products.Add(product);
            }


        }

        private async void btn_Addproduct_Clicked(object sender, EventArgs e)
        {
            var productRegistration = new ProductRegistration
            {
                ArticleNumber = articleNumber.Text,
                Title = productTitle.Text,
                CategoryName = categoryName.Text,
            };

            await _productService.CreateProductAsync(productRegistration);

            articleNumber.Text = string.Empty;
            productTitle.Text = string.Empty;
            categoryName.Text = string.Empty;

            return 
        }
    }
}