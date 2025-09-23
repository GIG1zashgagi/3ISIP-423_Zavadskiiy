using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopInventory
{
    public enum ProductCategory
    {
        Electronics,
        Clothing,
        Food,
        Books,
        Sports
    }

    public class Product
    {
        // Свойства товара
        public string Code { get; set; }       
        public string Name { get; set; }         
        public decimal Price { get; set; }         
        public int Quantity { get; set; }          
        public bool InStock => Quantity > 0;       
        public ProductCategory Category { get; set; } 

        public Product(string code, string name, decimal price, int quantity, ProductCategory category)
        {
            Code = code;
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }

        public override string ToString()
        {
            return $"Код: {Code}, " + $"Название: {Name}, Цена: {Price:C}, Количество: {Quantity}, " + $"В наличии: {(InStock ? "Да" : "Нет")}, Категория: {Category}";
        }
    }

    public class InventoryManager
    {
        private List<Product> products;     
        private int nextProductId;        

        public InventoryManager()
        {
            products = new List<Product>();
            nextProductId = 1001;
        }

        private string GenerateProductCode()
        {
            string code = "1" + nextProductId++.ToString("D4").Substring(1);
            return code;
        }
    }
}