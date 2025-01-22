using System;
using System.Collections.Generic;

namespace ConversionNombresRomains
{
    public class RomanNumbersConverter
    {
        // List des valeurs romaines
        private static readonly Dictionary<char, int> RomansValues = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public int Convert(string romanNumber)
        {
            if (string.IsNullOrWhiteSpace(romanNumber))
                throw new ArgumentException("Le nombre romain ne peut pas être vide");

            if (!IsNumberRomainValid(romanNumber))
                throw new ArgumentException("Format de nombre romain invalide");

            int total = 0;
            int valeurPrecedente = 0;

            // Parcours du nombre romain de droite à gauche
            for (int i = romanNumber.Length - 1; i >= 0; i--)
            {
                int valeurActuelle = RomansValues[romanNumber[i]];

                // Si la valeur précédente est plus grande, on soustrait la valeur actuelle
                if (valeurActuelle < valeurPrecedente)
                {
                    total -= valeurActuelle;
                }
                else
                {
                    total += valeurActuelle;
                }

                valeurPrecedente = valeurActuelle;
            }

            return total;
        }

        private bool IsNumberRomainValid(string romanNumber)
        {
            // Vérifie si tous les caractères sont des chiffres romains valides
            foreach (char c in romanNumber)
            {
                if (!RomansValues.ContainsKey(c))
                    return false;
            }

            // Vérifie les règles de répétition
            if (romanNumber.Contains("IIII") || 
                romanNumber.Contains("VV") || 
                romanNumber.Contains("XXXX") ||
                romanNumber.Contains("LL") ||
                romanNumber.Contains("CCCC") ||
                romanNumber.Contains("DD") ||
                romanNumber.Contains("MMMM"))
                return false;

            // Vérifie les combinaisons valides de soustraction
            var validCombinations = new[] { "IV", "IX", "XL", "XC", "CD", "CM" };
            var position = 0;
            while (position < romanNumber.Length - 1)
            {
                var deuxChars = romanNumber.Substring(position, 2);
                if (RomansValues[romanNumber[position]] < RomansValues[romanNumber[position + 1]])
                {
                    if (!validCombinations.Contains(deuxChars))
                        return false;
                    position += 2;
                }
                else
                {
                    position++;
                }
            }

            return true;
        }
    }
}
