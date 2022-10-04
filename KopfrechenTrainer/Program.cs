using System.Collections;

namespace KopfrechenTrainer;

class Programm
{
    public static void Main(String[] args)
    {
        ArrayList aufgaben = new ArrayList();
        Random rand = new Random();

        while (true)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nWieviele Aufgaben möchten Sie rechnen?");
            int anzahlAufgaben = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Welche Rechenart? (+;-;*;/;m[modulo])");
            string oper = Console.ReadLine();
            Console.WriteLine("Wie viele Sekunden zeit möchtest du pro sekunden haben?");
            int zeit = int.Parse(Console.ReadLine());

            switch (oper)
            {
                case "+":
                    for (int i = 0; i < anzahlAufgaben; i++)
                    {
                        aufgaben.Add(new Rechner('+', zeit, rand.Next(10)+1, rand.Next(10)+1));
                    }

                    break;
                case "-":
                    for (int i = 0; i < anzahlAufgaben; i++)
                    {
                        aufgaben.Add(new Rechner('-', zeit, rand.Next(10)+1, rand.Next(10)+1));
                    }

                    break;
                case "*":
                    for (int i = 0; i < anzahlAufgaben; i++)
                    {
                        aufgaben.Add(new Rechner('*', zeit, rand.Next(10)+1, rand.Next(10)+1));
                    }

                    break;
                case "/":
                    for (int i = 0; i < anzahlAufgaben; i++)
                    {
                        int random1 = rand.Next(10)+1;
                        int random2 = rand.Next(10)+1;
                        aufgaben.Add(new Rechner('/', zeit, random1 * random2, random2));
                    }

                    break;
                case "mod":
                    for (int i = 0; i < anzahlAufgaben; i++)
                    {
                        aufgaben.Add(new Rechner('m', zeit, rand.Next(100)+1 , rand.Next(10)+1));
                    }

                    break;
                default:
                    Console.WriteLine("Ungültiger Operator");
                    break;
            }


            for (int i = 0; i < anzahlAufgaben; i++)
            {
                Rechner temp = (Rechner)aufgaben[i];
                temp.startTimer();
                Console.Write(temp.ToString());
                
                int loesungsvorschlag = Int32.Parse(Console.ReadLine());

                if (temp.ueberpruefeErgebnis(loesungsvorschlag))
                {
                    Console.WriteLine("\n Richtig!!\n \n \n");
                }
                else
                {
                    Console.WriteLine("\n Falsch.\n \n \n");
                }
            }

            foreach (Rechner aufgabe in aufgaben)
            {
                Console.ResetColor();
                Console.Write(aufgabe.ToString()+"\t");
                if (aufgabe.Richtig)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("RICHTIG");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("FALSCH\t");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(aufgabe.Loesung);
                }
                Console.ResetColor();
            }
            Console.WriteLine("\n Die Konsole ist pausiert. Drücke irgendeine Taste zum fortsetzen.");
            Console.ReadLine();
        }
    }
}