using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace crossplat_1
{
    internal class Program
    {
        // Функция для расчета процентной ставки в зависимости от суммы вклада
        static double CalculateRate(double amount, int variant)
        {
            if      (amount < 100000)   { return 0.10; }
            else if (amount < 150000)   { return 0.10 - variant * 0.02; }
            else                        { return 0.10 - variant * 0.05; } 
            // с вариантом 3 ставка 0.1-3*0.05 = -0.05 ну мб так надо
        }

        // Функция для расчета итоговой суммы по вкладу за 10 лет с учетом изменения ставки каждый год
        static double CalculateFinalAmount(double initialAmount, int variant)
        {
            double currentAmount = initialAmount;
            for (int year = 1; year <= 10; year++)
            { currentAmount += currentAmount * CalculateRate(currentAmount, variant); }
            return currentAmount;
        }

        static void Main()
        {
            int N = 3;
            // исходники
            double deposit1 = 50000.0;
            double deposit2 = 100000.0;
            double deposit3 = 150000.0;
            // фин. суммы
            double finalAmount1 = CalculateFinalAmount(deposit1, N);
            double finalAmount2 = CalculateFinalAmount(deposit2, N);
            double finalAmount3 = CalculateFinalAmount(deposit3, N);

            // общее
            double finalTotal = Math.Round(finalAmount1 + finalAmount2 + finalAmount3, 2);
            Console.WriteLine($"{deposit1}  -> {Math.Round(finalAmount1, 2)}");
            Console.WriteLine($"{deposit2} -> {Math.Round(finalAmount2, 2)}");
            Console.WriteLine($"{deposit3} -> {Math.Round(finalAmount3, 2)}");
            Console.WriteLine($"Итоговая сумма по всем вкладам: {Math.Round(finalTotal, 2)} руб.");
        }
    }
}
