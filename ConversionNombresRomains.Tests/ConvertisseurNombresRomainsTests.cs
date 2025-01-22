using Xunit;

namespace ConversionNombresRomains.Tests
{
    public class RomanNumbersConverterTests
    {
        private readonly RomanNumbersConverter _convertisseur;

        public RomanNumbersConverterTests()
        {
            _convertisseur = new RomanNumbersConverter();
        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("IV", 4)]
        [InlineData("V", 5)]
        [InlineData("IX", 9)]
        [InlineData("X", 10)]
        [InlineData("XL", 40)]
        [InlineData("L", 50)]
        [InlineData("XC", 90)]
        [InlineData("C", 100)]
        [InlineData("CD", 400)]
        [InlineData("D", 500)]
        [InlineData("CM", 900)]
        [InlineData("M", 1000)]
        [InlineData("MCMXCIX", 1999)]
        [InlineData("MMXXIV", 2024)]
        public void Convert_NombresRomainsValides_RetourneNombresArabes(string romanNumber, int attendu)
        {
            int resultat = _convertisseur.Convert(romanNumber);
            Assert.Equal(attendu, resultat);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("IIII")] // Répétition invalide
        [InlineData("VV")]   // Répétition invalide
        [InlineData("IC")]   // Soustraction invalide
        [InlineData("XM")]   // Soustraction invalide
        [InlineData("ABC")]  // Caractères invalides
        public void Convert_NombresRomainsInvalides_LanceException(string romanNumber)
        {
            Assert.Throws<ArgumentException>(() => _convertisseur.Convert(romanNumber));
        }
    }
}