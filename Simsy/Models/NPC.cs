using Simsy.Interface;
using Simsy.Models;

public enum NPCEmotion
{
    Neutral,
    Happy,
    Angry,
    Surprised
}

public class NPC : INPC
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int RelationshipLevel { get; set; } = 0;
    public bool Met { get; set; } = false;
    public string Gender { get; set; }
    private Random rng = new Random();

    public NPC(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public void Greet(Person character)
    {
        Met = true;
        NPCEmotion reaction = (NPCEmotion)rng.Next(0, 4);
        Console.WriteLine($"{Name} ({Gender}) mowi: ");

        switch (reaction)
        {
            case NPCEmotion.Happy:
                Console.WriteLine("\"Hej! Ale sie ciesze ze cie widze!\" ");
                RelationshipLevel += 10;
                break;
            case NPCEmotion.Angry:
                Console.WriteLine("\"Och... ty znowu...\" ");
                RelationshipLevel -= 5;
                break;
            case NPCEmotion.Surprised:
                Console.WriteLine("\"O, nie spodziewalam sie ciebie.\" ");
                RelationshipLevel += 2;
                break;
            default:
                Console.WriteLine("\"Czesc.\" ");
                break;
        }
    }

    public void Talk(Person character)
    {
        Console.WriteLine($"{Name}: \"Fajnie bylo pogadac.\" ");
        RelationshipLevel += 5;
        character.Statistics.Happiness += 3;
    }

    public void GiveGift(Person character)
    {
        Console.WriteLine($"{Name} daje ci prezent ");
        character.Wallet.Earn(30);
        RelationshipLevel += 7;
    }

    public void Kiss(Person character)
    {
        if (RelationshipLevel < 60 || Gender != "Kobieta")
        {
            Console.WriteLine("Nie mozesz sprobowac pocalunku z ta osoba.");
            return;
        }

        Console.WriteLine($"Probujesz pocalowac {Name}... ");

        int reaction = rng.Next(0, 3);
        switch (reaction)
        {
            case 0:
                Console.WriteLine($"{Name} odwzajemnia pocalunek ");
                RelationshipLevel += 15;
                break;
            case 1:
                Console.WriteLine($"{Name} mowi: \"Hej... to za szybko.\" ");
                RelationshipLevel -= 10;
                break;
            case 2:
                Console.WriteLine($"{Name} sie odsuwa i wyglada na zla. ");
                RelationshipLevel -= 20;
                break;
        }
    }
}
