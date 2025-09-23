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
            return $"Код: {Code}, Название: {Name}, Цена: {Price:C}, Количество: {Quantity}, " +
                   $"В наличии: {(InStock ? "Да" : "Нет")}, Категория: {Category}";
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
            return "1" + (nextProductId++).ToString("D4").Substring(1);
        }

        public void AddProduct(string name, decimal price, int quantity, ProductCategory category)
        {
            string code = GenerateProductCode();
            Product newProduct = new Product(code, name, price, quantity, category);
            products.Add(newProduct);
            Console.WriteLine($" Товар добавлен: {newProduct}");
        }

        public void RemoveProduct(string code)
        {
            Product product = products.FirstOrDefault(p => p.Code == code);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine($" Товар с кодом {code} удален.");
            }
            else
            {
                Console.WriteLine($" Товар с кодом {code} не найден.");
            }
        }

        public void OrderSupply(string code, int quantity)
        {
            Product product = products.FirstOrDefault(p => p.Code == code);
            if (product != null)
            {
                product.Quantity += quantity;
                Console.WriteLine($" Поставка выполнена. Новое количество товара '{product.Name}': {product.Quantity}");
            }
            else
            {
                Console.WriteLine($" Товар с кодом {code} не найден.");
            }
        }
    }
}