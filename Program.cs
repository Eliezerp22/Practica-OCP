using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_OCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal income, decimal deduction);
    }

    public class IndiaTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal income, decimal deduction)
        {
            decimal taxableIncome = income - deduction;

            return taxableIncome * 0.15m; 
        }
    }

    public class UsaTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal income, decimal deduction)
        {
            decimal taxableIncome = income - deduction;

            return taxableIncome * 0.20m; 
        }
    }

    public class UkTaxCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal income, decimal deduction)
        {
            decimal taxableIncome = income - deduction;
           
            return taxableIncome * 0.18m; 
        }
    }

    public class TaxCalculator
    {
        private readonly Dictionary<string, ITaxCalculator> _calculators;

        public TaxCalculator()
        {
            _calculators = new Dictionary<string, ITaxCalculator>
        {
            { "India", new IndiaTaxCalculator() },
            { "USA", new UsaTaxCalculator() },
            { "UK", new UkTaxCalculator() }
        };
        }

        public decimal Calculate(decimal income, decimal deduction, string country)
        {
            if (_calculators.TryGetValue(country, out ITaxCalculator calculator))
            {
                return calculator.CalculateTax(income, deduction);
            }

            throw new ArgumentException("País no soportado");
        }
    }

}
