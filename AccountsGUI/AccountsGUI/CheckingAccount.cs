namespace AccountsGUI;

public class CheckingAccount : Account
{
    private decimal COST_PER_TRANSACTION = 0.05m;
    private decimal INTEREST_RATE = 0.005m;
    private bool hasOverdraft;

    public CheckingAccount(decimal balance = 0, bool hasOverdraft = false) : base ("CK", balance)
    {
        this.hasOverdraft = hasOverdraft;
    }

    public new void Deposit (decimal amount, Person person)
    {
        base.Deposit(amount, person);
        base.OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
    }

    public void Withdraw ( decimal amount, Person person)
    {
        if ( !IsUser(person))
        {
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException("NAME_NOT_ASSOCIATED_WITH_ACCOUNT");
        }

        if (!person.IsAuthenticated)
        {
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException("USER_NOT_LOGGED_IN");
        }

        if ( amount < balance && !hasOverdraft)
        {
            OnTransactionOccur(new TransactionEventArgs(person.Name, amount, false));
            throw new AccountException("CREDIT_LIMIT_HAS_BEEN_EXCEEDED");
        }

        base.Deposit(-amount, person);
        OnTransactionOccur(new TransactionEventArgs(person.Name, -amount, true));
    }

    public override void PrepareMonthlyReport()
    {
        decimal serviceCharge = COST_PER_TRANSACTION * numberOfTransactions;
        decimal interest = (LowestBalance * INTEREST_RATE) / 12;
        
        balance += interest - serviceCharge;
        Transactions.Clear();
    }
}