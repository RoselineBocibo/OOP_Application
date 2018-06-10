using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Application
{
    public enum TransactionType
    {
        DRAW = 1,
        DEPOSIT
    }
    
    class Program
    {
        private const string TRANSACTION_TYPE_DEP = "deposit";
        private const string TRANSACTION_TYPE_WITH = "withdrawal";

        static void Main(string[] args)
        {

            List<Account> accounts = new List<Account>
            {
                new Savings("Leroux", "McKay", 5, "LM", 3552, 5000, 0),
                new Current("Rosan", "Lundon", 25, "RN", 3500, 00, 0)
            };


            foreach (var acc in accounts)
            {
                if (acc is Savings)
                {

                    switch (GetInput())
                    {
                        case TransactionType.DRAW:
                            InfoBeforeTransaction(acc, TRANSACTION_TYPE_WITH);
                            acc.Withdrawal(500);
                            InfoAfterTransaction(acc, TRANSACTION_TYPE_WITH);
                            break;
                        case TransactionType.DEPOSIT:
                            InfoBeforeTransaction(acc, TRANSACTION_TYPE_DEP);
                            acc.ValidPassword("LM");
                            acc.Deposit(10000);
                            InfoAfterTransaction(acc, TRANSACTION_TYPE_DEP);
                            break;
                        default:
                            break;
                    }
                   
                }
                else
                {
                    switch (GetInput())
                    {
                        case TransactionType.DRAW:
                            InfoBeforeTransaction(acc, TRANSACTION_TYPE_WITH);
                            acc.Withdrawal(500);
                            InfoAfterTransaction(acc, TRANSACTION_TYPE_WITH);
                            break;
                        case TransactionType.DEPOSIT:
                            InfoBeforeTransaction(acc, TRANSACTION_TYPE_DEP);
                            acc.Deposit(10000);
                            InfoAfterTransaction(acc, TRANSACTION_TYPE_DEP);
                            break;
                        default:
                            break;
                    }
                }

            }

            Console.ReadLine();

        }

        private static void InfoAfterTransaction(Account acc, string transactionType)
        {
            Console.WriteLine($"Balance after {transactionType}");
            Console.WriteLine(acc.ToString());
        }

        private static void InfoBeforeTransaction(Account acc , string transactionType)
        {
            Console.WriteLine($"Balance before {transactionType}");
            Console.WriteLine(acc.ToString());
        }

        private static TransactionType GetInput()
        {
            Console.WriteLine("*************");
            Console.WriteLine("* 1. Withdraw *");
            Console.WriteLine("* 2. Deposit  *");
            Console.WriteLine("*************");
            TransactionType type = (TransactionType)int.Parse(Console.ReadLine());

            return type;
        }
    }
}
