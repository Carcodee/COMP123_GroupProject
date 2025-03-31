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
        AddPerson("Narendra", "1234-5678"); //0
        AddPerson("Ilia", "2345-6789"); //1
        AddPerson("Mehrdad", "3456-7890"); //2
        AddPerson("Vinay", "4567-8901"); //3
        AddPerson("Arben", "5678-9012"); //4
        AddPerson("Patrick", "6789-0123"); //5
        AddPerson("Yin", "7890-1234"); //6
        AddPerson("Hao", "8901-2345"); //7
        AddPerson("Jake", "9012-3456"); //8
        AddPerson("Mayy", "1224-5678"); //9
        AddPerson("Nicoletta", "2344-6789"); //10
//initialize the ACCOUNTS collection
        // AddAccount(new VisaAccount()); //VS-100000
        // AddAccount(new VisaAccount(150, -500)); //VS-100001
        // AddAccount(new SavingAccount(5000)); //SV-100002
        // AddAccount(new SavingAccount()); //SV-100003
        // AddAccount(new CheckingAccount(2000)); //CK-100004
        // AddAccount(new CheckingAccount(1500, true));//CK-100005
        // AddAccount(new VisaAccount(50, -550)); //VS-100006
        // AddAccount(new SavingAccount(1000)); //SV-100007
//associate users with accounts
        string number = "VS-100000";
        AddUserToAccount(number, "Narendra");
        AddUserToAccount(number, "Ilia");
        AddUserToAccount(number, "Mehrdad");
        number = "VS-100001";
        AddUserToAccount(number, "Vinay");
        AddUserToAccount(number, "Arben");
        AddUserToAccount(number, "Patrick");
        number = "SV-100002";
        AddUserToAccount(number, "Yin");
        AddUserToAccount(number, "Hao");
        AddUserToAccount(number, "Jake");
        number = "SV-100003";
        AddUserToAccount(number, "Mayy");
        AddUserToAccount(number, "Nicoletta");
        number = "CK-100004";
        AddUserToAccount(number, "Mehrdad");
        AddUserToAccount(number, "Arben");
        AddUserToAccount(number, "Yin");
        number = "CK-100005";
        AddUserToAccount(number, "Jake");
        AddUserToAccount(number, "Nicoletta");
        number = "VS-100006";
        AddUserToAccount(number, "Ilia");
        AddUserToAccount(number, "Vinay");
        number = "SV-100007";
        AddUserToAccount(number, "Patrick");
        AddUserToAccount(number, "Hao");
    }

    public static void AddPerson(string name, string sin)
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
