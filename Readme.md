# Convertisseur de Nombres Romains

Ce projet est un convertisseur de nombres romains en nombres arabes développé en C# avec .NET Core. Il permet de transformer des nombres romains (ex: XIV, MMXXIV) en leurs équivalents arabes (ex: 14, 2024) de manière interactive.

## Fonctionnalités

- Conversion de nombres romains en nombres arabes
- Mode interactif avec boucle continue (sortie avec '0000')
- Validation stricte des règles de notation romaine via expressions régulières
- Gestion des erreurs pour les entrées invalides
- Suite de tests unitaires complète
- Interface utilisateur en console avec retours visuels

## Prérequis

- .NET SDK 7.0 ou supérieur
- Visual Studio Code ou tout autre IDE compatible .NET
- Les extensions VSCode recommandées :
  - C# Dev Kit
  - .NET Core Test Explorer
  - NuGet Package Manager

## Installation

```bash
# Cloner le dépôt
git clone [url-du-depot]
cd ConversionNombresRomains

# Restaurer les dépendances
dotnet restore

# Compiler le projet
dotnet build
```

## Structure du Projet

```
ConversionNombresRomains/
├── ConversionNombresRomains.sln
├── ConversionNombresRomains/
│   ├── Program.cs                        # Point d'entrée et interface utilisateur
│   ├── RomanNumbersConverter.cs          # Logique de conversion
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
=== Convertisseur de Nombres Romains ===
Entrez un nombre romain ou '0000' pour quitter
----------------------------------------

Nombre romain > XIV
Résultat : 14
----------------------------------------

Nombre romain > MMXXIV
Résultat : 2024
----------------------------------------

Nombre romain > 0000
Au revoir !
```

## Règles de Validation

Les nombres romains sont validés selon les règles suivantes via des expressions régulières :

1. Format global : ^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$

   - M peut apparaître 0 à 3 fois
   - Les centaines peuvent être CM, CD, ou D suivie de 0 à 3 C
   - Les dizaines peuvent être XC, XL, ou L suivie de 0 à 3 X
   - Les unités peuvent être IX, IV, ou V suivie de 0 à 3 I

2. Caractères valides :

   - I (1)
   - V (5)
   - X (10)
   - L (50)
   - C (100)
   - D (500)
   - M (1000)

3. Soustractions valides uniquement pour :
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

- Les conversions de base
- Les cas de soustraction
- Les nombres composés
- Les répétitions valides et invalides
- Les soustractions valides et invalides
- Les caractères invalides
- Les structures invalides
- Les cas limites

## Dépannage

Problèmes courants et solutions :

1. **Erreur "Le nombre romain ne peut pas être vide"**

   - Assurez-vous d'entrer une valeur
   - Vérifiez qu'il n'y a pas uniquement des espaces

2. **Erreur "Format de nombre romain invalide"**

   - Vérifiez que seuls les caractères I, V, X, L, C, D, M sont utilisés
   - Vérifiez les règles de répétition
   - Vérifiez que les soustractions sont valides

3. **Warning dans les tests**
   - Utilisez string? pour les tests avec null
   - Évitez les doublons dans les données de test
   - Vérifiez la syntaxe des InlineData

## Contribution

1. Forkez le projet
2. Créez une branche pour votre fonctionnalité
3. Committez vos changements
4. Poussez vers la branche
5. Ouvrez une Pull Request

## Licence

Ce projet est sous licence MIT. Voir le fichier LICENSE pour plus de détails.
