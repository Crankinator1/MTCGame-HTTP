namespace MTCGame
{
    public class Stack
    {
        public Stack(string owner)
        {
            this.Owner = owner;
        }
        public List<GameCard> NormalStack { get; set; }
        public List<GameCard> BattleStack { get; set; }
        
        public string Owner { get; set; }

        public void Generate(int packages) //ID#s müssen bei zwei käufen aufsummiert werden(2packs --> id 1-10 kaufe wieder 2packs id 11-20
        {
            NormalStack = new List<GameCard>();
            for (int i = 1; i <= packages * 5; i++)
            {
                string monstertype = "";
                string name;
                string elementtype = "";
                int damage;
                int cardType;
                int randgenerator;
                Random rand = new Random();
                cardType = rand.Next(0, 2);
                randgenerator = rand.Next(0, 3);
                switch (randgenerator)
                {
                    case 0:
                        elementtype = "Fire";
                        break;
                    case 1:
                        elementtype = "Water";
                        break;
                    case 2:
                        elementtype = "Normal";
                        break;
                    default:
                        Console.WriteLine("RandomNumber hat nicht gepasst");
                        break;
                }

                randgenerator = rand.Next(1, 101);
                damage = randgenerator;

                if (cardType == 0)
                {
                    name = elementtype + "Spell";
                    SpellCard spell = new SpellCard(elementtype, damage, name, i, Owner);
                    NormalStack.Add(spell);

                }
                else
                {
                    name = elementtype;
                    randgenerator = rand.Next(0, 8);
                    switch (randgenerator)
                    {
                        case 0:
                            name += "Goblin";
                            monstertype = "Goblin";
                            break;
                        case 1:
                            name += "Knight";
                            monstertype = "Knight";
                            break;
                        case 2:
                            name += "Dragon";
                            monstertype = "Dragon";
                            break;
                        case 3:
                            name += "Troll";
                            monstertype = "Troll";
                            break;
                        case 4:
                            name += "Kraken";
                            monstertype = "Kraken";
                            break;
                        case 5:
                            name += "Ork";
                            monstertype = "Ork";
                            break;
                        case 6:
                            name += "Wizzard";
                            monstertype = "Wizzard";
                            break;
                        case 7:
                            name += "Elve";
                            monstertype = "Elve";
                            break;
                        default:
                            Console.WriteLine("Ungültiger Random-Wert");
                            break;

                    }

                    MonsterCard monster = new MonsterCard(elementtype, damage, name, i, monstertype, Owner);
                    NormalStack.Add(monster);
                }

            }
        }

        public void ChooseForBattle()
        //Edgecases: Karten doppelt wählen. Falsche Eingaben.
        {
            List<int> selectedCards = new List<int>();
            BattleStack = new List<GameCard>();
            Console.WriteLine("Please select your best 4 Cards! You can choose a Card by typing the ID and press Enter!");
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine("Please enter ID" + i); //Hier vlt noch den Usernamen übergeben
                selectedCards.Add(Convert.ToInt32(Console.ReadLine()));
            } 

            foreach (GameCard card in NormalStack)
            {
                if (card.id == selectedCards[0] || card.id == selectedCards[1] ||card.id == selectedCards[2] ||card.id == selectedCards[3])
                {
                    BattleStack.Add(card);
                }
            }
        }

        public void PrintStack(string stackVersion) // Wichtig checken wenn stack null ist
        //Vielleicht auch noch in User unterteilen
        {
            if (stackVersion == "normal")
            {
                Console.WriteLine("NORMALSTACK");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("----------------------------------------------");
                foreach (GameCard card in NormalStack)
                {
                    Console.WriteLine("Name: " + card.name);
                    Console.WriteLine("Elementtype: " + card.elementtype);
                    Console.WriteLine("Damage: " + card.damage);
                    Console.WriteLine("ID: " + card.id);
                    Console.WriteLine("----------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("BATTLESTACK");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("----------------------------------------------");
                foreach (GameCard card in BattleStack)
                {
                    Console.WriteLine("Name: " + card.name);
                    Console.WriteLine("Elementtype: " + card.elementtype);
                    Console.WriteLine("Damage: " + card.damage);
                    Console.WriteLine("ID: " + card.id);
                    Console.WriteLine("----------------------------------------------");
                }
            }
        }
    }
}

