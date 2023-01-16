namespace Swe1.TestApp;

public class BattleGround
{
    public BattleGround(User user1, User user2)
    {
        Board = new LiveBoard(1);
        User1 = user1;
        User2 = user2;
    }
    public User User1 { get; set; } // möglicherweise set am ende wegnehmen
    public User User2 { get; set; } // möglicherweise set am ende wegnehmen
    public LiveBoard Board { get; set; }

    public void GreatBattle()
    {
        Console.WriteLine("Welcome to BATTLEGROUND!");
        while (User1 is null || User2 is null)
        {
            Console.WriteLine("Waiting for one more Player...");
        }
        GameCard card1;
        GameCard card2;
        List<GameCard> battleStack1 = User1.Stack.BattleStack;
        List<GameCard> battleStack2 = User2.Stack.BattleStack;
        Console.WriteLine("Let the Fight begin");
        Console.WriteLine("Username: " + User1.UserName);
        Console.WriteLine("ELO: " + User1.EloValue);
        PrintBattleGround();
        Console.WriteLine("Username: " + User2.UserName);
        Console.WriteLine("ELO: " + User2.EloValue);
        while (battleStack1.Count > 0 && battleStack2.Count > 0 && Board.Round <= 100)
        {
            card1 = PickCard(battleStack1);
            card2 = PickCard(battleStack2);
            Board.Printround();
            Board.Round++;
            PrintCard(card1);
            PrintBattleGround();
            PrintCard(card2);
            if (card1 is MonsterCard && card2 is MonsterCard)
            {
                Console.WriteLine("\nMONSTERFIGHT");
                MonsterFight(card1, card2, battleStack1, battleStack2);
            }
            else if (card1 is SpellCard && card2 is SpellCard)
            {
                Console.WriteLine("\nSPELLFIGHT");
                SpellFight(card1, card2, battleStack1, battleStack2); //Zusätzlich allgemein multiplizierter Damage ausgeben lassen
            }
            else
            {
                Console.WriteLine("\nMIXEDFIGHT");
                MixedFight(card1, card2, battleStack1, battleStack2);
            }
        }
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("---------------------------------------------");
        if (battleStack1.Count > battleStack2.Count)
        {
            Console.WriteLine("User1 wins with " + battleStack1.Count + ":" + battleStack2.Count);
            User1.EloValue += 3;
            User2.EloValue -= 5;
        }
        else if (battleStack1.Count < battleStack2.Count)
        {
            Console.WriteLine("User2 wins with " + battleStack2.Count + ":" + battleStack1.Count);
            User2.EloValue += 3;
            User1.EloValue -= 5;
        }
        else
        {
            Console.WriteLine("Draw " + battleStack2.Count + ":" + battleStack1.Count);
        }
        
        Console.WriteLine("New Elo User1: " + User1.EloValue);
        Console.WriteLine("New Elo User2: " + User2.EloValue);
        
        ResetCard(User1, User2);
        ResetCard(User2, User1);

    }

    public void MonsterFight(GameCard card1, GameCard card2, List<GameCard> battleStack1, List<GameCard> battleStack2)
    {
        if (card1.monstertype == "Dragon" && card2.monstertype == "Goblin")
        {
            Console.WriteLine("Dragon defeats Goblin");
            MoveCard(card2, battleStack1, battleStack2);
        }
        else if (card1.monstertype == "Goblin" && card2.monstertype == "Dragon")
        {
            Console.WriteLine("Dragon defeats Goblin");
            MoveCard(card1, battleStack2, battleStack1);
        }
        else if (card1.monstertype == "Wizzard" && card2.monstertype == "Ork")
        {
            Console.WriteLine("Wizzard defeats Ork");
            MoveCard(card2, battleStack1, battleStack2);
        }
        else if (card1.monstertype == "Ork" && card2.monstertype == "Wizzard")
        {
            Console.WriteLine("Wizzard defeats Ork");
            MoveCard(card1, battleStack2, battleStack1);
        }
        else if (card1.name == "FireElve" && card2.monstertype == "Dragon")
        {
            Console.WriteLine("FireElve defeats Dragon");
            MoveCard(card2, battleStack1, battleStack2);
        }
        else if (card1.monstertype == "Dragon" && card2.name == "FireElve")
        {
            Console.WriteLine("FireElve defeats Dragon");
            MoveCard(card1, battleStack2, battleStack1);
        }
        else if (card1.damage > card2.damage)
        {
            Console.WriteLine(card1.name + " wins ");
            MoveCard(card2, battleStack1, battleStack2);
        }
        else if (card1.damage < card2.damage)
        {
            Console.WriteLine(card2.name + " wins ");
            MoveCard(card1, battleStack2, battleStack1);
        }
        else if (card1.damage == card2.damage)
        {
            Console.WriteLine("Draw");
        }
    }

    public void SpellFight(GameCard card1, GameCard card2, List<GameCard> battleStack1, List<GameCard> battleStack2)
    {
        int damage1 = card1.damage;
        int damage2 = card2.damage;
        if (card1.elementtype == "Fire" && card2.elementtype == "Normal") //Fehler kann entstehen wegen /2 bei ungeraden zahlen
        {
            damage1 *= 2;
            damage2 /= 2;
        }
        else if (card1.elementtype == "Normal" && card2.elementtype == "Fire")
        {
            damage1 /= 2;
            damage2 *= 2;
        }
        else if (card1.elementtype == "Normal" && card2.elementtype == "Water")
        {
            damage1 *= 2;
            damage2 /= 2;
        }
        else if (card1.elementtype == "Water" && card2.elementtype == "Normal")
        {
            damage1 /= 2;
            damage2 *= 2;
        }
        else if (card1.elementtype == "Water" && card2.elementtype == "Fire")
        {
            damage1 *= 2;
            damage2 /= 2;
        }
        else if (card1.elementtype == "Fire" && card2.elementtype == "Water")
        {
            damage1 /= 2;
            damage2 *= 2;
        }
        if (damage1 > damage2)
        {
            Console.WriteLine(card1.name + " wins ");
            MoveCard(card2, battleStack1, battleStack2);
        }
        else if (damage1 < damage2)
        {
            Console.WriteLine(card2.name + " wins ");
            MoveCard(card1, battleStack2, battleStack1);
        }
        else if (damage1 == damage2)
        {
            Console.WriteLine("Draw");
        }
    }

    public void MixedFight(GameCard card1, GameCard card2, List<GameCard> battleStack1, List<GameCard> battleStack2)
    {
        if (card1.name == "WaterSpell" && card2.monstertype == "Knight")
        {
            Console.WriteLine("WaterSpell defeats Knight");
            MoveCard(card2, battleStack1, battleStack2);
        }
        else if (card1.monstertype == "Knight" && card2.name == "WaterSpell")
        {
            Console.WriteLine("WaterSpell defeats Knight");
            MoveCard(card1, battleStack2, battleStack1);
        }
        else if (card1.monstertype == "Kraken" && card2 is SpellCard)
        {
            Console.WriteLine("Kraken defeats " + card2.name);
            MoveCard(card2, battleStack1, battleStack2);
        }
        else if (card1 is SpellCard && card2.monstertype == "Kraken")
        {
            Console.WriteLine("Kraken defeats " + card1.name);
            MoveCard(card1, battleStack2, battleStack1);
        }
        else
        {
            SpellFight(card1, card2, battleStack1, battleStack2);
        }
    }

    public void MoveCard(GameCard card, List<GameCard> battleStackWin, List<GameCard> battleStackLose)
    {
        battleStackWin.Add(card);
        battleStackLose.Remove(card);
    }

    public void ResetCard(User userOne, User userTwo)
    {
        foreach (GameCard card in userOne.Stack.BattleStack.ToList())
        {
            if (card.owner == userTwo.UserName)
            {
                userTwo.Stack.BattleStack.Add(card);
                userOne.Stack.BattleStack.Remove(card);
                
            }
        }
    }
    public GameCard PickCard(List<GameCard> battleStack)
    {
        Random rand = new Random();
        int randgenerator = rand.Next(0, battleStack.Count);
        return battleStack.ElementAt(randgenerator); 
    }
    public void PrintCard(GameCard card)
    {
        Console.WriteLine("Name: " + card.name);
        Console.WriteLine("Elementtype: " + card.elementtype);
        Console.WriteLine("Damage: " + card.damage);
    }
    public void PrintBattleGround()
    {
        Console.WriteLine("___  ________");
        Console.WriteLine("\\  \\/ /  ___/");
        Console.WriteLine(" \\   /\\___ \\");
        Console.WriteLine("  \\_//____  >");
        Console.WriteLine("          \\/ ");
    }
}