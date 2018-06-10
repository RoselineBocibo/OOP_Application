using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Application
{
    public class Current : Account
    {
        private string password;
        private decimal accountBalance;
        private decimal amountDeposited;
        private decimal bankCharge;

        private const double DEPOSITINTEREST = 0.15;
        private const double WITHDRAWALINTEREST = 0.1;
        public Current(string fName, string lName, int age, string password, decimal balance, decimal amountDeposit, decimal bankCharge)
           : base(fName, lName, age)
        {
            this.password = password;
            accountBalance = balance;
            amountDeposited = amountDeposit;
            this.bankCharge = bankCharge;
        }

        public sealed override void Deposit(decimal amount)
        {
            amountDeposited += amount;
            accountBalance += amountDeposited;

            BankCharges(amount, TransactionType.DEPOSIT);
        }

        public override bool ValidPassword(string password)
        {
            if (password != $"{firstName.Substring(0, 1)}{lastName.Substring(lastName.Length - 1, 1)}")
            {
                throw new ArgumentException("Enter correct pin code");
            }
            else
            {
                return true;
            }
        }

        public sealed override void Withdrawal(decimal amount)
        {

            if (amount > accountBalance)
            {
                throw new ArgumentException("Enter amount that is below your account balance");
            }
            else
            {
                accountBalance -= amount;
                BankCharges(amount, TransactionType.DRAW);

            }
        }

        public void BankCharges(decimal amount, TransactionType transactionType)
        {
            switch (transactionType)
            {
                case TransactionType.DRAW:
                    bankCharge += amount * (decimal)WITHDRAWALINTEREST;
                    break;
                case TransactionType.DEPOSIT:
                    bankCharge += amount * (decimal)DEPOSITINTEREST;
                    break;
                default:
                    break;
            }
          
        }



        public override string ToString()
        {
            return $"{base.ToString()}\t {password}\t{accountBalance}\t{amountDeposited}\t{bankCharge}"; 
        }
    }
}
