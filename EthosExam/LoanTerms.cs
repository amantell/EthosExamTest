using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading.Tasks;

namespace EthosExam
{
    class LoanTerms
    {
        private int _amount;
        private double _interest;
        private int _downpayment;
        private int _term;

        private int _amountFailures = 0;
        private int _interestFailures = 0;
        private int _downpaymentFailures = 0;
        private int _termFailures = 0;

        public int Amount { get { return _amount; } }
        public double Interest { get { return _interest; } }
        public int Downpayment { get { return _downpayment; } }
        public int Term { get { return _term; } }

        public bool HasAmountFailed { get { return (_amountFailures > 0); } }
        public bool HasInterestFailed { get { return (_interestFailures > 0); } }
        public bool HasDownpaymentFailed { get { return (_downpaymentFailures > 0); } }
        public bool HasTermFailed { get { return (_termFailures > 0); } }

        public void SetAmount(string amount)
        {
            if (!int.TryParse(amount, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out _amount)) _amountFailures++;
        }

        public void SetInterest(string interest)
        {
            if (!double.TryParse(interest, out _interest))
            {
                string pattern = @"\d+[\.\d+]?%?";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(interest))
                {
                    if (!double.TryParse(interest.Substring(0, interest.Length - 1), out _interest)) _interestFailures++;
                } else
                {
                    _interestFailures++;
                }
            } else
            {
                if (_interest <= 0) _interestFailures++;
            }
        }

        public void SetDownpayment(string downpayment)
        {
            if (!int.TryParse(downpayment, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out _downpayment)) _downpaymentFailures++;
        }

        public void SetTerm(string term)
        {
            if (!int.TryParse(term, NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out _term)) _termFailures++;
        }
    }
}

