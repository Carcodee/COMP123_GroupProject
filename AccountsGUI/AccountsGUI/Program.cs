using System.Transactions;

namespace AccountsGUI;

class Program
{
    public enum  AccountExceptionType
    {
        ACCOUNT_DOES_NOT_EXIST,
        ACCOUNT_ALREADY_EXIST,
        CREDIT_LIMIT_HAS_BEEN_EXCEEDED,
        INSUFFICIENT_FUNDS,
        NAME_NOT_ASSOCIATED_WITH_ACCOUNT,
        NO_OVERDRAFT_FOR_THIS_ACCOUNT,
        PASSWORD_INCORRECT,
        USER_DOES_NOT_EXIST,
        USER_ALREADY_EXIST,
        USER_NOT_LOGGED_IN
    }

    public static class Logger
    {
        private static List<string> loginEvents;
        private static List<string> transactionEvents;

        public static void LoginHandler(object sender, LoginEventArgs args)
        {
            string PersonName = args.PersonName;
            string Success = args.Success;
        }

        public static void TransactionHandler(object sender, TransactionEventArgs args)
        {
            string PersonName;
            string Amount;
            string Operation;
            string Success;
        }

        public static void DispalyLoginEvents(string filename)
        {
            Console.WriteLine(loginEvents.Count);
        }

        public static void DisplayTransactionEvents()
        {
            Console.WriteLine(transactionEvents.Count);
        }
    }

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
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

