using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EthosExam
{
    class Program
    {
        static void Main(string[] args)
        {

            LoanTerms loanTerms = new LoanTerms();

            while (loanTerms.Amount <= 0)
            {
                Console.WriteLine("amount:");
                if (loanTerms.HasAmountFailed)
                {
                    Console.WriteLine("Please type an integer above zero:");
                }
                var amount = Console.ReadLine();
                loanTerms.SetAmount(amount);
            }

            while (loanTerms.Interest <= 0)
            {
                Console.WriteLine("interest:");
                if (loanTerms.HasInterestFailed)
                {
                    Console.WriteLine("Please type a percentage above zero:");
                }
                var interest = Console.ReadLine();
                loanTerms.SetInterest(interest);
            }

            while (loanTerms.Downpayment <= 0)
            {
                Console.WriteLine("downpayment:");
                if (loanTerms.HasDownpaymentFailed)
                {
                    Console.WriteLine("Please type an integer above zero:");
                }
                var downpayment = Console.ReadLine();
                loanTerms.SetDownpayment(downpayment);
            }

            while (loanTerms.Term <= 0)
            {
                Console.WriteLine("term:");
                if (loanTerms.HasTermFailed)
                {
                    Console.WriteLine("Please type an integer above zero:");
                }
                var term = Console.ReadLine();
                loanTerms.SetTerm(term);
            }
            Console.WriteLine("");

            LoanProcessor loanProcessor = new LoanProcessor();
            loanProcessor.Calculate(loanTerms);
            Console.WriteLine(JsonConvert.SerializeObject(loanProcessor.LoanValues));
            Console.ReadKey();
        }
    }
}