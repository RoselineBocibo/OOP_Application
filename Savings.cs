using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Application
{
    public class Savings : Account
    {
        private string password;
        private decimal accountBalance;
        private decimal amountDeposited;
        private decimal bankCharge;

        private const double INTEREST = 0.15;
        public Savings(string fName, string lName, int age, string password, decimal balance, decimal amountDeposit, decimal bankCharge) 
            : base(fName, lName, age)
        {
            this.password = password;
            accountBalance = balance;
            amountDeposited = amountDeposit;
            this.bankCharge = bankCharge;
        }

        public sealed override void Withdrawal(decimal _amountWithdrawn)
        {
            if (_amountWithdrawn > accountBalance)
            {
                throw new ArgumentException("Enter amount that is below your account balance");
            }
            else
            {
                accountBalance -= _amountWithdrawn;
                BankCharges(_amountWithdrawn);

            }
        }

        public sealed override void Deposit(decimal amount)
        {
            this.amountDeposited += amount;
             accountBalance +=  amountDeposited;
            BankCharges(amount);
        }

        public void BankCharges(decimal amountDrawn)
        {
            bankCharge += amountDrawn * (decimal)INTEREST;

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

        public override string ToString()
        {
            return $"{base.ToString()}\t {password}\t{accountBalance}\t{amountDeposited}\t{bankCharge}";
        }
    }
}
