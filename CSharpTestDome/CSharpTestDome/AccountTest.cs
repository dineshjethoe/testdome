/*
    Using only NUnit's Assert.AreEqual method, write tests for the Account class that cover the following cases:

    The Deposit and Withdraw methods will not accept negative numbers.
    Account cannot overstep its overdraft limit.
    The Deposit and Withdraw methods will deposit or withdraw the correct amount, respectively.
    The Withdraw and Deposit methods return the correct results.

    Nuget:
    - Install-Package NUnit -Version 3.12.0 | https://www.nuget.org/packages/NUnit
    - Install-Package NUnit3TestAdapter -Version 3.15.1 | https://www.nuget.org/packages/NUnit3TestAdapter
 */

using NUnit.Framework;

namespace CSharpTestDome
{
    [TestFixture]
    public class Tester
    {
        private double epsilon = 1e-6; // use for comparing floating point numbers

        [Test]
        public void AccountCannotHaveNegativeOverdraftLimit()
        {
            var account = new Account(-20);

            Assert.AreEqual(0, account.OverdraftLimit, epsilon);
        }

        //The Deposit and Withdraw methods will not accept negative numbers
        [Test]
        public void DepositWillNotAcceptNegativeNumber()
        {
            var account = new Account(20);
            account.Deposit(-10);

            Assert.AreEqual(0d, account.Balance, epsilon);
        }

        [Test]
        public void WithdrawWillNotAcceptNegativeNumber()
        {
            var account = new Account(20);
            account.Withdraw(-10);

            Assert.AreEqual(0d, account.Balance, epsilon);
        }

        //The Deposit and Withdraw methods will deposit or withdraw the correct amount, respectively
        /*
            This test is expected to test if correct amounts are deposited or withdrawn, 
                resulting in expected operations performed on the Balance data member using the OverdraftLimit data member. 
        */
        [Test]
        public void DepositAPositiveAmount()
        {
            var account = new Account(20);
            account.Deposit(10);

            Assert.AreEqual(10d, account.Balance, epsilon);
        }

        [Test]
        public void WithdrawAPositiveAmountAndNotExceedingOverdraftLimit()
        {
            var account = new Account(20);
            account.Withdraw(10);

            Assert.AreEqual(-10d, account.Balance, epsilon);
        }


        //Account cannot overstep its overdraft limit
        [Test]
        public void AccountCannotOverstepOverdraftLimit()
        {
            var account = new Account(20);
            account.Withdraw(30);

            Assert.AreEqual(0d, account.Balance, epsilon); //balance is 0 since there's no deposit and 20 is less than 30 (limit < withdrawn amount)
        }

        //The Withdraw and Deposit methods return the correct results
        /*
            This test is expected to test if the returned values (boolean) are correct in case of valid and invalid inputs. 
        */
        [Test]
        public void DepositAndWithdrawReturnCorrectResults()
        {
            var account = new Account(20);
            var resultWithdrawnAmount = account.Withdraw(20);
            var resultDepositAmount = account.Deposit(50);

            //test passed when both are true
            Assert.AreEqual(resultWithdrawnAmount, resultDepositAmount);
        }
    }

    public class Account
    {
        public double Balance { get; private set; }
        public double OverdraftLimit { get; private set; }

        public Account(double overdraftLimit)
        {
            this.Balance = 0;
            this.OverdraftLimit = overdraftLimit > 0 ? overdraftLimit : 0;
        }

        public bool Deposit(double amount)
        {
            if (amount >= 0)
            {
                this.Balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(double amount)
        {
            if (this.Balance - amount >= -this.OverdraftLimit && amount >= 0)
            {
                this.Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
