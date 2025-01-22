# Convertisseur de Nombres Romains

Ce projet est un convertisseur de nombres romains en nombres arabes développé en C# avec .NET Core. Il permet de transformer des nombres romains (ex: XIV, MMXXIV) en leurs équivalents arabes (ex: 14, 2024).

## Fonctionnalités

- Conversion de nombres romains en nombres arabes
- Validation des règles de notation romaine
- Gestion des erreurs pour les entrées invalides
- Suite de tests unitaires complète

## Prérequis

- .NET SDK 7.0 ou supérieur

## Structure du Projet

```
ConversionNombresRomains/
├── ConversionNombresRomains.sln
├── ConversionNombresRomains/
│   ├── Program.cs
│   ├── RomanNumbersConverter.cs
│   └── ConversionNombresRomains.csproj
└── ConversionNombresRomains.Tests/
    ├── RomanNumbersConverterTests.cs
    └── ConversionNombresRomains.Tests.csproj
```

## Utilisation

Pour exécuter l'application :

```bash
cd ConversionNombresRomains
dotnet run
```

Exemple d'utilisation :

```
Entrez un nombre romain :
XIV
Nombre arabe : 14
```

## Règles de Conversion

Les nombres romains suivent ces règles :

1. Les caractères valides sont : I (1), V (5), X (10), L (50), C (100), D (500), M (1000)
2. Un caractère ne peut pas être répété plus de trois fois consécutives
3. Les soustractions valides sont :
   - IV (4)
   - IX (9)
   - XL (40)
   - XC (90)
   - CD (400)
   - CM (900)

## Tests

Pour exécuter les tests unitaires :

```bash
cd ConversionNombresRomains.Tests
dotnet test
```

Les tests couvrent :

- Les conversions de base (I → 1, V → 5, etc.)
- Les cas de soustraction (IV → 4, IX → 9, etc.)
- Les nombres composés (XIV → 14, MMXXIV → 2024, etc.)
- La validation des entrées invalides

## Dépannage

Problèmes courants et solutions :

1. **Erreur "Le nombre romain ne peut pas être vide"**

   - Assurez-vous d'entrer une valeur
   - Vérifiez qu'il n'y a pas uniquement des espaces

2. **Erreur "Format de nombre romain invalide"**
   - Vérifiez que seuls les caractères I, V, X, L, C, D, M sont utilisés
   - Vérifiez les règles de répétition
   - Vérifiez que les soustractions sont valides
