namespace COMP123_GroupProject;
internal class LoginEventHandler
{
}
public class Person
{
    private string password;
    private LoginEventHandler onLogin;

    public string Sin { get;}
    public string Name { get;}
    public bool IsAuthenticated { get;}

    public Person(string name, string sin)
    {
        Sin = sin;
        Name = name;
    }

    public void Login(string password)
    {
        
    }
    public void Logout()
    {
            
    }

    public override string ToString()
    {
        return base.ToString();
    }
}

