namespace KopfrechenTrainer;

public class Rechner
{
    private char rechenzeichen;
    private String text;
    private Boolean? richtig;
    private Timer? timer;
    private int sec;
    private int var1, var2;
    private int loesung;

    public Rechner(char rechenzeichen, int sec, int var1, int var2)
    {
        this.var1 = var1;
        this.var2 = var2;
        this.sec = sec;
        timer = null;
        richtig = null;
        this.rechenzeichen = rechenzeichen;

        switch (rechenzeichen)
        {
            case '+':
                text = " plus ";
                loesung = var1 + var2;
                break;
            case '-':
                text = " minus ";
                loesung = var1 - var2;
                break;
            case '*':
                text = " mal ";
                loesung = var1 * var2;
                break;
            case '/':
                text = " geteilt ";
                loesung = var1 / var2;
                break;
            case 'm':
                text = " modulo ";
                loesung = var1 % var2;
                break;
            default:
                Console.WriteLine(" Unpassender Operator ");
                rechenzeichen = 'E';
                text = " ERROR ";
                break;
        }
    }

    public void startTimer()
    {
        timer = new Timer(DateTime.Now, DateTime.Now.AddSeconds(sec));
    }

    public Boolean ueberpruefeErgebnis(int ergebniss)
    {
        if (timer == null)
        {
            Console.WriteLine("ERROR: Timer not started");
            return false;
        }

        if (timer.timeLeft() == 0)
        {
            Console.WriteLine("you took to long");
            richtig = false;
            return false;
        }

        if (loesung == ergebniss)
        {
            richtig = true;
            return true;
        }


        richtig = false;
        return false;
    }

    public override String ToString()
    {
        return "Aufgabe: " + var1 + " " + rechenzeichen + " " + var2 + "= ";
    }

    public int Loesung
    {
        get { return loesung; }
    }

    public bool Richtig
    {
        get { return (bool)richtig; }
    }
    
    
}