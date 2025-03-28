using System;
namespace AccountsGUI
{
	public struct Transaction
	{
		public string AccountNumber { get; }
        public decimal Amount { get; }
        public Person Originator { get; }
        public DayTime Time { get; }

        public Transaction(string accountNumber, decimal amount, Person person)
            => (this.AccountNumber, this.Amount, this.Originator) = (accountNumber, amount, person);

        public override string ToString()
        {
            return $"{AccountNumber} ${Amount} {Originator.Name} {Time}";
            // Example VS-100000 $1,500.00 Narendra 2025-03-22 16:17
        }
    }
}

