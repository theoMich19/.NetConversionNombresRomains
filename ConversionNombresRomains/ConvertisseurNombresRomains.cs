using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConversionNombresRomains
{
    public class RomanNumbersConverter
    {
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

        // Regex pour valider la structure globale d'un nombre romain
        private static readonly string RomanNumberPattern =
            @"^(?=.)?" +                    // Non vide
            @"M{0,3}" +                     // Milliers: 0-3 M
            @"(CM|CD|D?C{0,3})" +          // Centaines: CM, CD, D00-DCCC
            @"(XC|XL|L?X{0,3})" +          // Dizaines: XC, XL, L00-LXXX
            @"(IX|IV|V?I{0,3})$";          // Unités: IX, IV, V00-VIII

        // Regex pour vérifier les répétitions invalides
        private static readonly string InvalidRepeatPattern =
            @"I{4,}|V{2,}|X{4,}|L{2,}|C{4,}|D{2,}|M{4,}";

        // Regex pour vérifier les soustractions invalides
        private static readonly string InvalidSubtractionPattern =
            @"I[LCDM]|V[XLCDM]|X[DM]|L[CM]|V[V]|L[L]|D[D]";

        public int Convert(string romanNumber)
        {
            if (string.IsNullOrWhiteSpace(romanNumber))
                throw new ArgumentException("Le nombre romain ne peut pas être vide");

            romanNumber = romanNumber.Trim().ToUpper();

            if (!IsValidRomanNumber(romanNumber))
                throw new ArgumentException("Format de nombre romain invalide");

            return CalculateValue(romanNumber);
        }

        private bool IsValidRomanNumber(string romanNumber)
        {
            // Vérifie la structure globale
            if (!Regex.IsMatch(romanNumber, RomanNumberPattern))
                return false;

            // Vérifie l'absence de répétitions invalides
            if (Regex.IsMatch(romanNumber, InvalidRepeatPattern))
                return false;

            // Vérifie l'absence de soustractions invalides
            if (Regex.IsMatch(romanNumber, InvalidSubtractionPattern))
                return false;

            return true;
        }

        private int CalculateValue(string romanNumber)
        {
            int total = 0;
            int previousValue = 0;

            // Parcours du nombre romain de droite à gauche
            for (int i = romanNumber.Length - 1; i >= 0; i--)
            {
                int currentValue = RomansValues[romanNumber[i]];

                if (currentValue < previousValue)
                {
                    total -= currentValue;
                }
                else
                {
                    total += currentValue;
                }

                previousValue = currentValue;
            }

            return total;
        }
    }
}