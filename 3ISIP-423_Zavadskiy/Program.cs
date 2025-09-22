using System;
using System.Collections.Generic;
using System.Linq;

class Expense
{
    public string Name { get; set; }    
    public decimal Amount { get; set; } 
    public override string ToString() => $"{Name}; {Amount} руб.";
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== УЧЕТ РАСХОДОВ ===");
        int count = GetNumber("Введите количество операций (2-40): ", 2, 40);

        var expenses = InputExpenses(count);

        while (true)
        {
            Console.WriteLine("\n=== ГЛАВНОЕ МЕНЮ ===");
            Console.WriteLine("1. Показать все расходы");
            Console.WriteLine("2. Посмотреть статистику");
            Console.WriteLine("3. Отсортировать по цене");
            Console.WriteLine("4. Конвертировать в другую валюту");
            Console.WriteLine("5. Найти покупку по названию");
            Console.WriteLine("0. Выйти из программы");

            int choice = GetNumber("Выберите пункт меню: ", 0, 5);

            switch (choice)
            {
                case 1: ShowExpenses(expenses); break;     
                case 2: ShowStats(expenses); break;         
                case 3: SortExpenses(expenses); break;      
                case 4: ConvertCurrency(expenses); break;   
                case 5: SearchExpenses(expenses); break;   
                case 0: return;                            
            }
        }
    }
    static int GetNumber(string message, int min, int max)
    {
        int number;
        do
        {
            Console.Write(message);
        } while (!int.TryParse(Console.ReadLine(), out number) || number < min || number > max);
        return number;
    }
    static List<Expense> InputExpenses(int count)
    {
        var expenses = new List<Expense>(); 
        Console.WriteLine($"\nВведите {count} операций в формате: Название; Сумма");
        Console.WriteLine("Пример: Кофе; 150");

        for (int i = 0; i < count; i++)
        {
            while (true)
            {
                Console.Write($"{i + 1}. ");
                string input = Console.ReadLine();
                string[] parts = input.Split(';');

                if (parts.Length == 2 &&
                    decimal.TryParse(parts[1].Trim(), out decimal amount) &&
                    amount > 0)
                {
                    expenses.Add(new Expense
                    {
                        Name = parts[0].Trim(),   
                        Amount = amount           
                    });
                    break;
                }
                Console.WriteLine("Ошибка! Используйте формат: Название; Сумма");
            }
        }
        return expenses;
    }
    static void ShowExpenses(List<Expense> expenses)
    {
        Console.WriteLine("\n=== ВАШИ РАСХОДЫ ===");

        if (!expenses.Any())
        {
            Console.WriteLine("Нет данных о расходах.");
            return;
        }

        for (int i = 0; i < expenses.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {expenses[i]}");
        }
    }
}