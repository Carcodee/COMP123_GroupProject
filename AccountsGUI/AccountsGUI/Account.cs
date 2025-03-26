using System.Transactions;

namespace AccountsGUI;


abstract class Account 
{
        protected List<Person> users { get; } //?
        public List<Transaction> transactions { get; }
        private int LAST_NUMBER = 100_000;
        private event TransactionEventhandler OnTransaction; //?

        protected decimal Balance
        {
            public get { } //?
            protected set {} //?
        }

        protected decimal LowestBalance
        {
            public get { } //?
            protected set { } //?
        }

        string Number
        {
            public get { } //?
        }

        public Account(string type, decimal balance)
        {
            Number.Concat(); //?
            LAST_NUMBER = LAST_NUMBER + 1;
            Balance = balance; //?
            LowestBalance = 0; //?
        }

        protected void Deposit(decimal balance, Person person)
        {
            Balance += balance;
            LowestBalance = Balance;
            object Transaction = Number;
            transactions.Add(person);
        }

        public void AddUser(Person Person)
        {
        }

        public bool IsUser(string name)
        {
        }

        public abstract void PrepareMonthlyReport()
        {
        }

        public virtual void OnTransactionOccur(object sender, TransactionEventArgs e)
        {
            
        }

        public override string ToString()
        {
            
        }
}