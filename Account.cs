using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Application

{
    public abstract class Account 
    {
        #region Public fields
        public string firstName;
        public string lastName;
        public int age;
        #endregion

        #region Constructor

        public Account(string fName, string lName, int age)
        {
            firstName = fName;
            lastName = lName;
            this.age = age;
        }
        #endregion

        #region Properties

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                this.age = value;
            }
        }
        #endregion

        public abstract void Withdrawal(decimal amount);

        public abstract void Deposit(decimal amountDeposited);

        public override string ToString()
        {
            return $"{FirstName}\t {LastName}\t{Age}";
        }

        public abstract bool ValidPassword(string password);
       
    }
}
