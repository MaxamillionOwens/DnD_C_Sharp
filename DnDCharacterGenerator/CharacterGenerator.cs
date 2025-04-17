using System;
using System.Collections.Generic;

class Character
{
    public string Name;
    public string Race;
    public string Gender;
    public string Class;
    public int Level;
    public int Strength;
    public int Dexterity;
    public int Constitution;
    public int Intelligence;
    public int Wisdom;
    public int Charisma;
    public string[] Skills;
    public string[] Feats;
}

static class CharacterGenerator
{
    private static Random random = new Random();

    private static string ChooseName(string race, string gender)
    {
        Dictionary<string, Dictionary<string, string[]>> namesByRace = new Dictionary<string, Dictionary<string, string[]>>
        {
            {"Human", new Dictionary<string, string[]>
                {
                    {"Male", new string[] {"John", "David", "Michael", "Christopher", "James", "Matthew", "Daniel", "Andrew", "William", "Joseph"}},
                    {"Female", new string[] {"Sarah", "Emily", "Jessica", "Jennifer", "Elizabeth", "Amy", "Michelle", "Melissa", "Nicole", "Stephanie"}}
                }
            },
            {"Elf", new Dictionary<string, string[]>
                {
                    {"Male", new string[] {"Legolas", "Aragorn", "Gandalf", "Elrond", "Thranduil", "Haldir", "Celeborn", "Gil-galad", "Fingolfin", "Eärendil"}},
                    {"Female", new string[] {"Arwen", "Galadriel", "Eowyn", "Lúthien", "Aredhel", "Idril", "Finduilas", "Nimrodel", "Celebrían", "Earwen"}}
                }
            },
            {"Dwarf", new Dictionary<string, string[]>
                {
                    {"Male", new string[] {"Gimli", "Thorin", "Balin", "Dwalin", "Fili", "Kili", "Oin", "Gloin", "Dori", "Nori"}},
                    {"Female", new string[] {"Dís", "Elda", "Fríða", "Hilda", "Helga", "Ingrid", "Sigrun", "Unnur", "Gudrun", "Hedvig"}}
                }
            },
            {"Halfling", new Dictionary<string, string[]>
                {
                    {"Male", new string[] {"Frodo", "Bilbo", "Samwise", "Peregrin", "Meriadoc", "Hob", "Marcho", "Paladin", "Primula", "Rory"}},
                    {"Female", new string[] {"Rosie", "Merry", "Pippin", "Poppy", "Daisy", "Ruby", "Beryl", "Cora", "Esme", "Wilhelmina"}}
                }
            },
            {"Dragonborn", new Dictionary<string, string[]>
                {
                    {"Male", new string[] {"Drake", "Ragnar", "Vorstag", "Thulsa", "Kazuki", "Kaedan", "Raiden", "Hakon", "Jareth", "Torin"}},
                    {"Female", new string[] {"Sera", "Lithia", "Velika", "Kaida", "Zara", "Reyna", "Elys", "Mara", "Vera", "Aria"}}
                }
            },
            {"Gnome", new Dictionary<string, string[]>
                {
                    {"Male", new string[] {"Gimble", "Ricket", "Zook", "Fizzwick", "Pip", "Tock", "Wizzle", "Quix", "Muddle", "Blim"}},
                    {"Female", new string[] {"Wren", "Bixi", "Fizzbang", "Tink", "Pip", "Zara", "Flick", "Dixie", "Quinn", "Miri"}}
                }
            },
            {"Half-Elf", new Dictionary<string, string[]>
                {
                    {"Male", new string[] {"Erevan", "Galen", "Rowan", "Caelan", "Eldrin", "Lorian", "Alden", "Rylan", "Kieran", "Soren"}},
                    {"Female", new string[] {"Ariana", "Elysia", "Lyra", "Elara", "Evelyn", "Aislinn", "Faela", "Aria", "Lorelei", "Sylvia"}}
                }
            },
            {"Half-Orc", new Dictionary<string, string[]>
                {
                    {"Male", new string[] {"Gorruk", "Thokk", "Morg", "Drokk", "Gromm", "Skarr", "Brakk", "Gruumsh", "Varg", "Razgul"}},
                    {"Female", new string[] {"Ursa", "Shara", "Lokra", "Ghazra", "Zogga", "Grima", "Hakka", "Mogga", "Zarra", "Ghorza"}}
                }
            },
            {"Tiefling", new Dictionary<string, string[]>
                {
                    {"Male", new string[] {"Zephyrus", "Mephistopheles", "Belial", "Lucifer", "Asmodeus", "Leviathan", "Baalzebul", "Moloch", "Diablo", "Samael"}},
                    {"Female", new string[] {"Lilith", "Raven", "Succubus", "Morrigan", "Lamia", "Jezebeth", "Azazel", "Nyarlathotep", "Kali", "Hecate"}}
                }
            }
        };

        if (namesByRace.ContainsKey(race) && namesByRace[race].ContainsKey(gender))
        {
            string[] names = namesByRace[race][gender];
            int randomIndex = GetRandomInt(0, names.Length - 1);
            return names[randomIndex];
        }

        return "Unknown";
    }

    private static int GetRandomInt(int min, int max)
    {
        return random.Next(min, max + 1);
    }

    public static Character GenerateCharacter(string race, string gender, string characterClass)
    {
        Character character = new Character();
        character.Name = ChooseName(race, gender);
        character.Race = race;
        character.Gender = gender;
        character.Class = characterClass;
        character.Level = GetRandomInt(1, 5);
        character.Strength = GetRandomInt(6, 18);
        character.Dexterity = GetRandomInt(6, 18);
        character.Constitution = GetRandomInt(6, 18);
        character.Intelligence = GetRandomInt(6, 18);
        character.Wisdom = GetRandomInt(6, 18);
        character.Charisma = GetRandomInt(6, 18);
        character.Skills = GetSkillsForClass(characterClass);
        character.Feats = GetFeatsForRace(race);
        return character;
    }

    private static string[] GetSkillsForClass(string characterClass)
    {
        Dictionary<string, string[]> skillsByClass = new Dictionary<string, string[]>
        {
            {"Fighter", new string[] {"Athletics", "Intimidation", "Survival"}},
            {"Wizard", new string[] {"Arcana", "History", "Investigation"}},
            {"Rogue", new string[] {"Acrobatics", "Deception", "Stealth"}},
            {"Cleric", new string[] {"Medicine", "Persuasion", "Religion"}},
            {"Paladin", new string[] {"Insight", "Intimidation", "Religion"}},
            {"Bard", new string[] {"Deception", "Performance", "Persuasion"}}
        };

        if (skillsByClass.ContainsKey(characterClass))
        {
            return skillsByClass[characterClass];
        }

        return new string[0];
    }

    private static string[] GetFeatsForRace(string race)
    {
        Dictionary<string, string[]> featsByRace = new Dictionary<string, string[]>
        {
            {"Human", new string[] {"Lucky", "Skilled", "Variant", "Observant", "Resilient", "Mobile", "War Caster", "Actor", "Tough", "Alert"}},
            {"Elf", new string[] {"Elven Accuracy", "Fey Teleportation", "Trance", "Wood Elf Magic", "Elven Weapon Training", "Mask of the Wild", "Keen Senses", "Fleet of Foot", "High Elf Cantrip", "Elven Accuracy"}},
            {"Dwarf", new string[] {"Dwarven Toughness", "Stonecunning", "Tool Proficiency", "Dwarven Resilience", "Dwarven Combat Training", "Dwarven Armor Training", "Dwarven Weapon Training", "Dwarven Fortitude", "Dwarven Knowledge", "Dwarven Ingenuity"}},
            {"Halfling", new string[] {"Lucky", "Brave", "Halfling Nimbleness", "Second Chance", "Stout Resilience", "Bountiful Luck", "Squat Nimbleness", "Naturally Stealthy", "Stout Resilience", "Second Chance"}},
            {"Half-Elf", new string[] {"Skill Versatility", "Fey Ancestry", "Extra Language", "Darkvision", "Fey Ancestry", "Skill Versatility", "Dilettante", "Versatile Talent", "Ancestral Guardian", "Mask of the Wild"}},
            {"Half-Orc", new string[] {"Menacing", "Relentless Endurance", "Savage Attacks", "Powerful Build", "Aggressive", "Primal Intuition", "Brutish Durability", "Orcish Fury", "Swift Charge", "Savage Critical"}},
            {"Dragonborn", new string[] {"Draconic Ancestry", "Breath Weapon", "Damage Resistance", "Draconic Roar", "Draconic Wings", "Draconic Senses", "Dragon Fear", "Dragon Hide", "Dragon Wings", "Dragon Fear"}},
            {"Gnome", new string[] {"Gnome Cunning", "Artificer's Lore", "Tinker", "Gnome Magic", "Speak with Small Beasts", "Fury of the Small", "Fade Away", "Tinkerer", "Minor Illusion", "Clockwork Toy"}},
            {"Tiefling", new string[] {"Infernal Legacy", "Hellish Resistance", "Darkness", "Legacy of Stygia", "Winged", "Legacy of Malbolge", "Hellfire", "Legacy of Cania", "Infernal Constitution", "Legacy of Avernus"}}
        };

        if (featsByRace.ContainsKey(race))
        {
            return featsByRace[race];
        }

        return new string[0];
    }
}
