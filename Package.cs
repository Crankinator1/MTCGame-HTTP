namespace Swe1.TestApp;

public class Package
{
    public Package()
    {
        
    }
    //Generell noch eine gute Struktur einfallen lassen, Man könnte ein Package an die main retounieren.
    public List<GameCard> Packages { get; set; }

    public void CreatePackage()
    {
        Packages = new List<GameCard>();
        string input;
        string name;
        string elementtype;
        int damage;
        //check if admin
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Card"+i+": (S)pellCard or (M)onsterCard?");
            do
            {
                input = Console.ReadLine();
                if (input != "S" && input != "M")
                {
                    Console.WriteLine("Incorrect Input! Please try again!");
                }
            } while (input != "S" && input != "M");
            switch(input)
            {
                case "S":
                    elementtype = CreateElement();
                    damage = CreateDamage();
                    name = elementtype += "Spell"; //schauen ob das funktioniert hat mit dem Namen
                    GameCard cardS = new SpellCard(elementtype, damage, name, -1, null);
                    Packages.Add(cardS); //Schauen ob das funktioniert
                    break;
                case "M":
                    elementtype = CreateElement();
                    damage = CreateDamage();
                    Console.WriteLine("Which Monstertype? Knight, Troll, Elve, Dragon, Goblin, Wizzard, Ork, Kraken. Please type the whole Name.");
                    do
                    {
                        input = Console.ReadLine();
                        if (input != "Knight" && input != "Troll" && input != "Elve" && input != "Dragon" &&
                            input != "Goblin" && input != "Wizzard" && input != "Ork" && input != "Kraken")
                        {
                            Console.WriteLine("Incorrect Input! Please try again!");
                        }
                    } while (input != "Knight" && input != "Troll" && input != "Elve" && input != "Dragon" &&
                             input != "Goblin" && input != "Wizzard" && input != "Ork" && input != "Kraken");

                    name = elementtype + input; //schauen ob das funktioniert hat mit dem Namen
                    GameCard cardM = new MonsterCard(elementtype, damage, name, -1, input, null);
                    Packages.Add(cardM);
                    break;
                
            }

        }
    }

    public string CreateElement()
    {
        string input;
        string elementtype = "";
        do
        {
            Console.WriteLine("Select between: (F)ire/(W)ater/(N)ormal");
            input = Console.ReadLine();
            if (input != "F" && input != "W" && input != "N")
            {
                Console.WriteLine("Incorrect Input! Please try again!");
            }
        } while (input != "F" && input != "W" && input != "N");

        switch (input)
        {
            case "F":
                elementtype = "Fire";
                break;
            case "W":
                elementtype = "Water";
                break;
            case "N":
                elementtype = "Normal";
                break;
        }
        return elementtype;
    }

    public int CreateDamage()
    {
        int damage;
        do
        {
            Console.WriteLine("Select between the Damage between 1-100.");
            while (!int.TryParse(Console.ReadLine(), out damage))
            {
                Console.WriteLine("Please Enter a valid numerical value!");
            }
        } while (damage > 100 || damage < 1);
        return damage;
    }
}