namespace COMP123_GroupProject;


public enum LoginEventType
{
    None,
    Login,
    Logout
}
public class DayTime
{
}
public class LoginEventArgs : EventArgs
{

    public string PersonName { get; }
    public bool Success { get; }
    public DayTime Time { get; }
    public LoginEventType EventType { get; }

    LoginEventArgs(string username, bool success, LoginEventType loginEventType)
    {
        PersonName = username;
        Success = success;
        EventType = loginEventType;
        //handle type
        //time = someutilfunc
    }
    
}
