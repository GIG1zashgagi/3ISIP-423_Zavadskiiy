using System;
using System.Collections.Generic;
using System.Linq;

class Expense
{
    public string Name { get; set; }    // Название товара или услуги
    public decimal Amount { get; set; } // Сумма в рублях
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
                case 1: ShowExpenses(expenses); break;      // Показать все расходы
                case 2: ShowStats(expenses); break;         // Показать статистику
                case 3: SortExpenses(expenses); break;      // Отсортировать
                case 4: ConvertCurrency(expenses); break;   // Конвертировать валюту
                case 5: SearchExpenses(expenses); break;    // Поиск по названию
                case 0: return;                            // Выход из программы
            }
        }
    }
    static int GetNumber(string message, int min, int max)
    {
        int number;
        do
        {
            Console.Write(message); // Показываем сообщение с просьбой ввода
            // Повторяем до тех пор, пока не получим правильное число
        } while (!int.TryParse(Console.ReadLine(), out number) || number < min || number > max);
        return number;
    }
    static List<Expense> InputExpenses(int count)
    {
        var expenses = new List<Expense>(); // Создаем пустой список для хранения расходов
        Console.WriteLine($"\nВведите {count} операций в формате: Название; Сумма");
        Console.WriteLine("Пример: Кофе; 150");

        for (int i = 0; i < count; i++)

    }
}