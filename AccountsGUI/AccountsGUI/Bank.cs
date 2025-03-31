using System.Text.Json;

namespace COMP123_GroupProject;
public class Account
{
}
public static class Bank
{
    static private readonly Dictionary<string, Account> ACCOUNTS;
    static private readonly Dictionary<string, Person> USERS;

    static Bank()
    {
        
    }

    public static void AddUser(string name, string sin)
    {
        try
        {
            if (USERS.ContainsKey(sin))
            {
                throw new AccountException(ExceptionType.PLACEHOLDER);
            }
            else
            {
                Person newUser = new Person(name, sin);
                USERS.Add(sin, newUser);
            }
        }
        catch (AccountException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public static void AddAccount(Account account)
    {
        try
        {
            // if (ACCOUNTS.ContainsKey(account.number))
            // {
            //     throw new AccountException(ExceptionType.PLACEHOLDER);
            // }
            // else
            // {
            //     // ACCOUNTS.Add(account.number, account);
            // }
        }
        catch (AccountException e)
        {
            Console.WriteLine(e);
            throw;
        }   
    }

    public static void AddUserToAccount(string number, string name)
    {
        Person person = GetUser(name);
        Account account = GetAccount(number);
        // account.AddUser(person);
    }
    
    public static Account GetAccount(string number)
    {
        try
        {
            if (!ACCOUNTS.ContainsKey(number))
            {
                throw new AccountException(ExceptionType.PLACEHOLDER);
            } 
            return ACCOUNTS.GetValueOrDefault(number);
        }
        catch (AccountException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static Person GetUser(string name)
    {
        try
        {
            foreach (var user in USERS)
            {
                if (user.Value.Name == name)
                {
                    return user.Value;
                } 
            }

            throw new AccountException(ExceptionType.PLACEHOLDER);
        }
        catch (AccountException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public static void PrintAccounts()
    {
        foreach (var account in ACCOUNTS)
        {
            Console.WriteLine(account.ToString());
        }
    }
    
    public static void PrintUsers()
    {
        foreach (var user in USERS)
        {
            Console.WriteLine(user.ToString());
        }
    }

    public static void SaveAccounts(string filename)
    {
        StreamWriter writer= new StreamWriter(filename);
        foreach (var account in ACCOUNTS)
        {
            string jsonText = JsonSerializer.Serialize(account);
            writer.Write(jsonText);
        }
        writer.Close();
    }
    public static void SaveUsers(string filename)
    {
        StreamWriter writer= new StreamWriter(filename);
        foreach (var user in USERS)
        {
            string jsonText = JsonSerializer.Serialize(user);
            writer.Write(jsonText);
        }
        writer.Close();
    }

}
