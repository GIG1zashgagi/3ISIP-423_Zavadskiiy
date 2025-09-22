using System;
using System.Collections.Generic;
using System.Linq;

class Expense
{
    public string Name { get; set; }    // Название товара или услуги
    public decimal Amount { get; set; } // Сумма в рублях

    // Метод для красивого вывода информации о расходе
    public override string ToString() => $"{Name}; {Amount} руб.";
}
