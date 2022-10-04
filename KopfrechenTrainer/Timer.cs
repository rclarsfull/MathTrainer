using System.Security.Authentication.ExtendedProtection;

namespace KopfrechenTrainer;


public class Timer
{
    public DateTime start, end; 

    public Timer(DateTime start,DateTime end)
    {
        this.end = end;
        this.start = start;
        
    }

    public int timeLeft()
    {
        if (this==null)
        {
            return 0;
        }
        int temp= (int)Math.Round(end.Subtract(DateTime.Now).TotalSeconds);
        if (temp < 0) temp = 0;
        return temp;
    }

    public DateTime Start
    {
        get { return start; }
    }

    public DateTime End
    {
        get { return end; }
    }
    
    
}