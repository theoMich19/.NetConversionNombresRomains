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
        [InlineData("III", 3)]
        [InlineData("XXXIX", 39)]
        [InlineData("CCXLVI", 246)]
        // Nouveaux cas de test pour les limites
        [InlineData("MMM", 3000)]         // Maximum de M consécutifs
        [InlineData("DCCC", 800)]         // Maximum de C après D
        [InlineData("LXXX", 80)]          // Maximum de X après L
        [InlineData("VIII", 8)]           // Maximum de I après V
        public void Convert_NombresRomainsValides_RetourneNombresArabes(string romanNumber, int attendu)
        {
            int resultat = _convertisseur.Convert(romanNumber);
            Assert.Equal(attendu, resultat);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Convert_EntreeVide_LanceException(string romanNumber)
        {
            Assert.Throws<ArgumentException>(() => _convertisseur.Convert(romanNumber));
        }

        [Theory]
        [InlineData("IIII")]              // 4 I consécutifs
        [InlineData("VV")]                // 2 V consécutifs
        [InlineData("XXXX")]              // 4 X consécutifs
        [InlineData("LL")]                // 2 L consécutifs
        [InlineData("CCCC")]              // 4 C consécutifs
        [InlineData("DD")]                // 2 D consécutifs
        [InlineData("MMMM")]              // 4 M consécutifs
        // Nouveaux cas pour les regex
        [InlineData("MMMMM")]             // 5 M consécutifs
        [InlineData("DCCCC")]             // 4 C après D
        [InlineData("LXXXX")]             // 4 X après L
        [InlineData("VIIII")]             // 4 I après V
        public void Convert_RepetitionsInvalides_LanceException(string romanNumber)
        {
            Assert.Throws<ArgumentException>(() => _convertisseur.Convert(romanNumber));
        }

        [Theory]
        [InlineData("IC")]                // I avant C
        [InlineData("XM")]                // X avant M
        [InlineData("VX")]                // V avant X
        [InlineData("LC")]                // L avant C
        [InlineData("DM")]                // D avant M
        [InlineData("IL")]                // I avant L
        [InlineData("IM")]                // I avant M
        [InlineData("XD")]                // X avant D
        [InlineData("VL")]                // V avant L
        public void Convert_SoustractionsInvalides_LanceException(string romanNumber)
        {
            Assert.Throws<ArgumentException>(() => _convertisseur.Convert(romanNumber));
        }

        [Theory]
        [InlineData("ABC")]               // Caractères non romains
        [InlineData("123")]               // Chiffres arabes
        [InlineData("XV2I")]              // Mélange de chiffres
        [InlineData("X V")]               // Espace au milieu
        [InlineData("X.V")]               // Ponctuation
        [InlineData("XIIV")]              // Structure invalide
        [InlineData("IVIV")]              // Double soustraction
        [InlineData("IIV")]               // Structure invalide avant V
        public void Convert_CaracteresInvalides_LanceException(string romanNumber)
        {
            Assert.Throws<ArgumentException>(() => _convertisseur.Convert(romanNumber));
        }

        [Theory]
        [InlineData("IVII")]              // Répétition après soustraction
        [InlineData("IVX")]               // Valeur plus grande après soustraction
        [InlineData("IVI")]               // Répétition invalide après soustraction
        [InlineData("IXI")]               // Répétition invalide après soustraction
        [InlineData("VIV")]               // Soustraction après une valeur plus grande
        [InlineData("XCX")]               // Répétition après soustraction
        // Nouveaux cas pour les structures invalides
        [InlineData("CMC")]               // Répétition après soustraction
        [InlineData("CDC")]               // Structure invalide avec C
        [InlineData("XCIX.")]             // Ponctuation à la fin
        public void Convert_StructureInvalide_LanceException(string romanNumber)
        {
            Assert.Throws<ArgumentException>(() => _convertisseur.Convert(romanNumber));
        }
    }
}