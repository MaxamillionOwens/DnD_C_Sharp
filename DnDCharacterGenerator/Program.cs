using System;
using System.Linq;

class Program
{

    static void Main()
    {
        string[] races = { "Human", "Elf", "Dwarf", "Halfling", "Dragonborn", "Gnome", "Half-Elf", "Half-Orc", "Tiefling" };
        string[] genders = { "Male", "Female" };
        string[] characterClasses = { "Fighter", "Wizard", "Rogue", "Cleric", "Paladin", "Bard" };

        Random random = new Random();
        string race = races[random.Next(races.Length)];
        string gender = genders[random.Next(genders.Length)];
        string characterClass = characterClasses[random.Next(characterClasses.Length)];

        Character character = CharacterGenerator.GenerateCharacter(race, gender, characterClass);

        Console.WriteLine($"Name: {character.Name}");
        Console.WriteLine($"Race: {character.Race}");
        Console.WriteLine($"Gender: {character.Gender}");
        Console.WriteLine($"Class: {character.Class}");
        Console.WriteLine($"Level: {character.Level}");
        Console.WriteLine($"Attributes:");
        Console.WriteLine($"  Strength: {character.Strength}");
        Console.WriteLine($"  Dexterity: {character.Dexterity}");
        Console.WriteLine($"  Constitution: {character.Constitution}");
        Console.WriteLine($"  Intelligence: {character.Intelligence}");
        Console.WriteLine($"  Wisdom: {character.Wisdom}");
        Console.WriteLine($"  Charisma: {character.Charisma}");
        Console.WriteLine($"Skills: {string.Join(", ", character.Skills)}");

        string[] randomFeats = character.Feats.OrderBy(_ => random.Next()).Take(1).ToArray();
        Console.WriteLine($"Feats: {string.Join(", ", randomFeats)}");
    }

}