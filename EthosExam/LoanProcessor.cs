using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthosExam
{
    class LoanProcessor
    {
        private Dictionary<string, decimal> _loanValues;

        public Dictionary<string, decimal> LoanValues { get { return _loanValues; } }

        public void Calculate(LoanTerms loanTerms)
        {
            double rate = (loanTerms.Interest / 12) * .01;
            int numberOfPeriods = loanTerms.Term * 12;
            int principal = loanTerms.Amount - loanTerms.Downpayment;

            double amortizationNumerator = rate * Math.Pow((1 + rate), numberOfPeriods);
            double amortizationDenominator = Math.Pow((1 + rate), numberOfPeriods) - 1;

            decimal monthlyPayment = Convert.ToDecimal(principal * (amortizationNumerator / amortizationDenominator));
            decimal totalPayment = (monthlyPayment * numberOfPeriods);
            decimal totalInterest = totalPayment - principal;

            _loanValues = new Dictionary<string, decimal>() { { "monthly payment", decimal.Round(monthlyPayment, 2) }, { "total interest", decimal.Round(totalInterest, 2) }, { "total payment", decimal.Round(totalPayment, 2) } };
        }
    }
}
