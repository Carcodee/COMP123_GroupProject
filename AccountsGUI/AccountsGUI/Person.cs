namespace AccountsGUI;

//public enum ExceptionType
//{
//    PLACEHOLDER
    
//}
//public delegate void LoginEventHandler(object sender, LoginEventArgs e);
//public class AccountException : Exception
//{
//    public ExceptionType Type { get; }

//    public AccountException(ExceptionType type)
//        : base(type.ToString())
//    {
//        Type = type;
//    }
//}
public class Person
{
    private string password;
    private LoginEventHandler onLogin;

    public string Sin { get;}
    public string Name { get;}
    public bool IsAuthenticated { get; private set; }


    public Person(string name, string sin)
    {
        Sin = sin;
        Name = name;
    }

    public void Login(string password)
    {
        if (password != this.password)
        {
            IsAuthenticated = false;
            onLogin?.Invoke(this, new LoginEventArgs(Name, false, LoginEventType.Login));
            throw new AccountException(ExceptionType.PLACEHOLDER);
        }

        IsAuthenticated = true;
        onLogin?.Invoke(this, new LoginEventArgs(Name, true, LoginEventType.Login));
    }
    public void Logout()
    {
        IsAuthenticated = false;
        onLogin?.Invoke(this, new LoginEventArgs(Name, true, LoginEventType.Logout));
    }

    public override string ToString()
    {
        return $"{Name} - Authenticated: {IsAuthenticated}";
    }
}

