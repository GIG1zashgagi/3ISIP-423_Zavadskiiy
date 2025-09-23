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
        public string Code { get; set; }           // Уникальный код
        public string Name { get; set; }           // Название
        public decimal Price { get; set; }         // Цена
        public int Quantity { get; set; }          // Количество
        public bool InStock => Quantity > 0;       // Автоматическое свойство наличия
        public ProductCategory Category { get; set; } // Категория

        public Product(string code, string name, decimal price, int quantity, ProductCategory category)
        {
            // Шаг 3.1: Инициализируем свойства значениями параметров
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
}