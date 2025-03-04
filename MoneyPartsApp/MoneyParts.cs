using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPartsApp
{
    class MoneyParts
    {
        private static readonly double[] Denominations = { 200, 100, 50, 20, 10, 5, 2, 1, 0.5, 0.2, 0.1, 0.05 };
        public List<List<double>> Build(string amountStr)
        {
            if (!double.TryParse(amountStr, out double amount) || amount <= 0)
            {
                throw new ArgumentException("El monto ingresado no es válido.");
            }

            var result = new List<List<double>>();
            FindCombinations(amount, new List<double>(), 0, result);
            return result;
        }

        private void FindCombinations(double remaining, List<double> combination, int index, List<List<double>> result)
        {
            if (remaining == 0)
            {
                result.Add(new List<double>(combination));
                return;
            }

            for (int i = index; i < Denominations.Length; i++)
            {
                if (Denominations[i] <= remaining)
                {
                    combination.Add(Denominations[i]);
                    FindCombinations(Math.Round(remaining - Denominations[i], 2), combination, i, result);
                    combination.RemoveAt(combination.Count - 1);
                }
            }
        }


    }
}
