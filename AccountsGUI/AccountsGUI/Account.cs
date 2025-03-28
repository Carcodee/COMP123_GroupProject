using System.Transactions;
using static AccountsGUI.Delegates;

namespace AccountsGUI;

abstract class Account 
{
    protected List<Person> users { get; } 
    public List<Transaction> transactions { get; }
    private int LAST_NUMBER = 100_000;
    private event TransactionEventHandler OnTransaction; 
    public decimal Balance { get; protected set; }
    public decimal LowestBalance { get; protected set; }
    public string Number { get; }

    public abstract void PrepareMonthlyReport();

    public Account(string type, decimal balance)
    {
        Number = $"{type}{LAST_NUMBER}";
        LAST_NUMBER = LAST_NUMBER + 1;
        Balance = balance;
        LowestBalance = 0; 
    }

    protected void Deposit(decimal balance, Person person)
    {
        Balance = balance;
        LowestBalance = Balance;
        Transaction t = new Transaction(this.Number, this.Balance, person);
        transactions.Add(t);
    }

    public void AddUser(Person Person)
    {
    }

    public bool IsUser(Person person)
    {
        return true;
    }

    public virtual void OnTransactionOccur(object sender, TransactionEventArgs e)
    {
        OnTransaction(sender, e);
    }

    public override string ToString()
    {
        return $"";
    }
}