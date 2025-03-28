﻿using static AccountsGUI.Delegates;

namespace AccountsGUI;

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
        return $"{Name} - Authenticated: {IsAuthenticated}";
    }
}

