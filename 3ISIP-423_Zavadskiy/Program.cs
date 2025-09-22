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
    }
}