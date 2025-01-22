using System;

namespace ConversionNombresRomains
{
    class Program
    {
        // Main programme convertisseur
        static void Main(string[] args)
        {
            var convertisseur = new RomanNumbersConverter();
            Console.WriteLine("Entrez un nombre romain :");
            string romanNumber = Console.ReadLine()?.ToUpper() ?? "";
            
            try
            {
                int resultat = convertisseur.Convert(romanNumber);
                Console.WriteLine($"Nombre arabe : {resultat}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Erreur : {e.Message}");
            }
        }
    }
}