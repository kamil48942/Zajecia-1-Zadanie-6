using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string sciezkaWejsciowegoPliku = "plik1.txt";
        string sciezkaWyjsciowegoPliku = "plik2.txt";

        try
        {
            using (FileStream wejsciowyPlik = new FileStream(sciezkaWejsciowegoPliku, FileMode.Open))
            {
                using (FileStream wyjsciowyPlik = new FileStream(sciezkaWyjsciowegoPliku, FileMode.Create))
                {
                    byte[] bufor = new byte[1024];
                    int odczytaneBajty;

                    while ((odczytaneBajty = wejsciowyPlik.Read(bufor, 0, bufor.Length)) > 0)
                    {
                        wyjsciowyPlik.Write(bufor, 0, odczytaneBajty);
                    }
                }
            }

            Console.WriteLine("Plik został skopiowany pomyślnie.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Wystąpił błąd: " + ex.Message);
        }

        Console.ReadKey();
    }
}
