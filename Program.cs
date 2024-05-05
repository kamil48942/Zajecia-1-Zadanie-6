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
            // Otwieramy istniejący plik do odczytu
            using (FileStream wejsciowyPlik = new FileStream(sciezkaWejsciowegoPliku, FileMode.Open))
            {
                // Tworzymy nowy plik do zapisu
                using (FileStream wyjsciowyPlik = new FileStream(sciezkaWyjsciowegoPliku, FileMode.Create))
                {
                    // Tworzymy bufor do przechowywania odczytanych danych
                    byte[] bufor = new byte[1024];
                    int odczytaneBajty;

                    // Odczytujemy dane z pliku wejściowego i zapisujemy je do pliku wyjściowego
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
