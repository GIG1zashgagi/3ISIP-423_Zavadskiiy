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

        public void SellProduct(string code, int quantity)
        {
            Product product = products.FirstOrDefault(p => p.Code == code);
            if (product != null)
            {
                if (product.Quantity >= quantity)
                {
                    product.Quantity -= quantity;
                    decimal totalPrice = product.Price * quantity;
                    Console.WriteLine($" Продажа выполнена.");
                    Console.WriteLine($" Продано {quantity} шт. товара '{product.Name}'");
                    Console.WriteLine($" Общая стоимость: {totalPrice:C}");
                    Console.WriteLine($" Остаток на складе: {product.Quantity}");
                }
                else
                {
                    Console.WriteLine($" Недостаточно товара на складе. Доступно: {product.Quantity}");
                }
            }
            else
            {
                Console.WriteLine($" Товар с кодом {code} не найден.");
            }
        }

        public void SearchByCode(string code)
        {
            var foundProducts = products.Where(p => p.Code == code).ToList();
            DisplaySearchResults(foundProducts, $"по коду '{code}'");
        }

        public void SearchByName(string name)
        {
            var foundProducts = products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            DisplaySearchResults(foundProducts, $"по названию '{name}'");
        }
        public void SearchByCategory(ProductCategory category)
        {
            var foundProducts = products.Where(p => p.Category == category).ToList();
            DisplaySearchResults(foundProducts, $"по категории '{category}'");
        }
    }
}