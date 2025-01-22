using System;

namespace ConversionNombresRomains
{
    class Program
    {
        // main program converter, stop ==> 0000
        static void Main(string[] args)
        {
            var convertisseur = new RomanNumbersConverter();
            bool continuer = true;

            Console.WriteLine("=== Convertisseur de Nombres Romains ===");
            Console.WriteLine("Entrez un nombre romain ou '0000' pour quitter");
            Console.WriteLine("----------------------------------------");

            while (continuer)
            {
                try
                {
                    Console.Write("\nNombre romain > ");
                    string input = Console.ReadLine()?.Trim().ToUpper() ?? "";

                    if (input == "0000")
                    {
                        continuer = false;
                        Console.WriteLine("\nAu revoir !");
                        continue;
                    }

                    int resultat = convertisseur.Convert(input);
                    Console.WriteLine($"Résultat : {resultat}");
                    Console.WriteLine("----------------------------------------");
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Erreur : {ex.Message}");
                    Console.ResetColor();
                    Console.WriteLine("----------------------------------------");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Erreur inattendue : {ex.Message}");
                    Console.ResetColor();
                    Console.WriteLine("----------------------------------------");
                }
            }
        }
    }
}