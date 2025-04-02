using static AccountsGUI.Delegates;
namespace AccountsGUI;
public class Person
{
    private string password;
    private LoginEventHandler onLogin = Logger.LoginHandler;

    public string Sin { get;}
    public string Name { get;}
    public bool IsAuthenticated { get; private set; }


    public Person(string name, string sin)
    {
        Sin = sin;
        Name = name;
        password = $"{sin[0]}{sin[1]}{sin[2]}";
    }

    public void Login(string password)
    {
        if (password != this.password)
        {
            IsAuthenticated = false;
            onLogin?.Invoke(this, new LoginEventArgs(Name, false, LoginEventType.Login));
            throw new AccountException(AccountExceptionType.PASSWORD_INCORRECT);
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
        return IsAuthenticated ? $"{Name} - Authenticated" : $"{Name} - Not Authenticated";
    }
}

