using DemoExam.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DemoExam.Scripts;
using DemoExam.Scripts.Models;

namespace DemoExam.Pages
{
    public partial class ProductPage : Page
    {
        private ApplicationContext db = new();
        private List<ProductCardData> productCardDatas;

        public ProductPage()
        {
            InitializeComponent();
            Loaded += ProductPage_Loaded;
        }

        private void ProductPage_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeCardDatas();
            ProductList.ItemsSource = productCardDatas;
        }

        private void InitializeCardDatas()
        {
            productCardDatas = new();

            foreach (Product product in db.products)
            {
                int totalAmount = 0;
                List<OrderItem> orderItems = new();

                foreach (StockItem stock in product.StockItems)
                {
                    totalAmount += stock.quantity;
                    orderItems.AddRange(stock.OrderItems);
                }

                string backgroundColor = totalAmount <= 3 ? "#FF8080" : "#D2F6E7";

                string imagePath = string.IsNullOrEmpty(product.image_file_name)
                    ? "/Images/picture.png"
                    : "/Images/Products/" + product.image_file_name;

                DateTime monthStart = new(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTime previousMonthStart = monthStart.AddMonths(-1);

                bool wasOrderedLastMonth = false;
                foreach (OrderItem orderItem in orderItems)
                {
                    DateTime orderDate = DateTime.Parse(orderItem.Order.order_date);
                    if (orderDate >= previousMonthStart && orderDate < monthStart)
                    {
                        wasOrderedLastMonth = true;
                    }
                }

                float computedPrice = wasOrderedLastMonth
                    ? product.price
                    : product.price * 0.75f;

                ProductCardData newData = new(
                    product,
                    totalAmount,
                    computedPrice,
                    product.Manufacturer.name + " | " + product.name,
                    imagePath,
                    backgroundColor
                );

                productCardDatas.Add(newData);
            }
        }
    }

    public record ProductCardData(
        Product Product,
        int TotalAmount,
        float ComputedPrice,
        string ManufacturerAndName,
        string ImagePath,
        string BackgroundColor
    );
}