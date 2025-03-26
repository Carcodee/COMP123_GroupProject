namespace AccountsGUI;

public class Util
{
    private static Random random = new Random();

    private static DateTime currentTime = new DateTime(2025, 3, 22, 10, 15, 0);

    public static DateTime Now
    {
        get
        {
            currentTime = currentTime.AddSeconds(random.Next(100));
            return currentTime;
        }
    }
}