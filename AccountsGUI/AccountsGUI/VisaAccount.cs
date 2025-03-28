using System;
using System.Security.Principal;
using System.Xml.Linq;

namespace AccountsGUI
{
	public class VisaAccount : Account, ITransaction
    {
		private decimal CreditLimit { get; }
		private static decimal INTEREST_RATE = 0.1995M;

		public VisaAccount(double balance = 0, decimal creditLimit = 1200M)
		{
			Account("VS", balance);
			this.CreditLimit = creditLimit;
		}

	}
	public void DoPayment(decimal amount, Person person)
	{
		TransactionEventArgs eventArgs = new TransactionEventArgs(person.Name, amount, true);
        Deposit(amount, person);
		OnTransactionOccur(person, eventArgs);
	}
	public void DoPurchase(decimal amount, Person person)
	{

	}
}



//2. public void DoPurchase(decimal amount, Person person) – this public
//method takes two arguments: a double representing the amount to be withdrawn and a
//person object representing the person do the transaction. The method does the following:
//a.If this person in not associated with this account, it does the following:
  //i.Calls the OnTransactionOccur() method of the base class with the
//appropriate arguments. Read the above Deposit() method for more
//explanation
//ii. Throws the appropriate AccountException object
//b. If this person in not logged in, it does the following:
//i.Calls the OnTransactionOccur() method of the base class with the
//appropriate arguments.
//ii. Throws the appropriate AccountException object.
//c. If the purchase amount is greater than the sum of the balance and the credit limit,
//it does the following:
//i.Calls the OnTransactionOccur() method of the base class with the
//appropriate arguments.
//ii. Throws the appropriate AccountException object.
//d. Otherwise it does the following:
//i.Calls the OnTransactionOccur() method of the base class with the
//appropriate arguments.
//ii. calls the Deposit() method of the base class with the appropriate
//arguments (you will send negative of the amount)


//3. public override void PrepareMonthlyReport() – this public method override
//the method of the base class with the same name. The method does the following:
//a.Calculate the interest by multiplying the LowestBalance by the InterestRate
//and then dividing by 12
//b. Update the Balance by subtraction the interest
//c. Transactions is re-initialized
//This method does not take any parameter nor does it display anything