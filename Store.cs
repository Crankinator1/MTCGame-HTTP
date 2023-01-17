namespace MTCGame;

public class Store
{
    public Store()
    {
        TradeList = new List<GameCard>();
        Seller = new List<UserPlayer>();
        RequirementsList = new List<GameCard>();
    }
    public List<GameCard> TradeList { get; set; }
    public List<GameCard> RequirementsList { get; set; }
    public UserPlayer ActiveSeller { get; set;}
    public UserPlayer ActiveCostumer { get; set;}
    public List<UserPlayer> Seller { get; set; }

    public void Sell()
    {
        int id;
        int sdamage;
        int mdamage;
        string type;
        Console.WriteLine("Please type the Id from your TradingCard: ");
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Please Enter a valid numerical value!");
        }

        foreach (GameCard card in ActiveSeller.Stack.NormalStack.ToList())
        {
            if (id == card.id)
            {
                
                card.sellID = TradeList.Count + 1;
                TradeList.Add(card);
                ActiveSeller.Stack.NormalStack.Remove(card);
                /*if(card in ActiveSeller.Stack.BattleStack)
                {
                    
                }*/
            }
        }
        Console.WriteLine("Which type would you like to have: (S)pellCard or (M)onsterCard: ");
        type = Console.ReadLine();
        if (type == "S")
        {
            Console.WriteLine("Please type in your required damage: ");
            while (!int.TryParse(Console.ReadLine(), out sdamage)) //überprüfen ob damage in den grenzen 1-100 liegt
            {   
                Console.WriteLine("Please Enter a valid numerical value!");
            }
            GameCard rCard = new SpellCard(null, sdamage, null, TradeList.Count, null);
            RequirementsList.Add(rCard);
        }
        if (type == "M")
        {
            Console.WriteLine("Please type in your required damage: ");
            while (!int.TryParse(Console.ReadLine(), out mdamage)) //überprüfen ob damage in den grenzen 1-100 liegt
            {   
                Console.WriteLine("Please Enter a valid numerical value!");
            }
            GameCard rCard = new MonsterCard(null, mdamage, null, TradeList.Count, null, null);
            RequirementsList.Add(rCard);
        }
    }
    
    public void Buy()
    {
        int inputbuy;
        int inputoffer;
        int tmp;
        PrintStore();
        Console.WriteLine("Which card would you like to have? Insert the ID!"); //Checken ob id überhaupt existiert
        while (!int.TryParse(Console.ReadLine(), out inputbuy))
        {   
            Console.WriteLine("Please Enter a valid numerical value!");
        }
        Console.WriteLine("Choose your card, which would you like to offer? Insert the ID!"); //Checken ob id überhaupt existiert
        while (!int.TryParse(Console.ReadLine(), out inputoffer))
        {   
            Console.WriteLine("Please Enter a valid numerical value!");
        }

        foreach (GameCard cardoffer in ActiveCostumer.Stack.NormalStack.ToList())
        {
            if (cardoffer.id == inputoffer)
            {
                foreach (GameCard cardr in RequirementsList.ToList())
                {
                    if (cardr.id == inputbuy && cardr.damage <= cardoffer.damage && cardr.GetType() == cardoffer.GetType())
                    {
                        foreach (GameCard cardbuy in TradeList.ToList())
                        {
                            if (inputbuy == cardbuy.sellID)
                            {
                                foreach (UserPlayer seller in Seller)
                                {
                                    if (cardbuy.owner == seller.UserName)
                                    {
                                        ActiveCostumer.Stack.NormalStack.Remove(cardoffer);
                                        TradeList.Remove(cardbuy);
                                        RequirementsList.Remove(cardr);
                                        tmp = cardbuy.id;
                                        cardbuy.id = cardoffer.id;
                                        cardoffer.id = tmp;
                                        cardbuy.owner = ActiveCostumer.UserName;
                                        cardoffer.owner = seller.UserName;
                                        ActiveCostumer.Stack.NormalStack.Add(cardbuy);
                                        seller.Stack.NormalStack.Add(cardoffer);
                                        Console.WriteLine("Trade Done!");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your Card doesn't expect the requirements!");
                    }
                }
            }
        }
    }

    public void PrintStore()
    {
        Console.WriteLine("##########################  STORE  ##########################");
        Console.WriteLine("#######################  TradingCards  ########################");
        foreach (GameCard card in TradeList)
        {
            Console.WriteLine("ID: " + card.sellID + "  Name: " + card.name + "  Elementtype: " + card.elementtype + "  Damage: " + card.damage);
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }
        Console.WriteLine("#######################  Requirements-Cards  ########################");
        foreach (GameCard card in RequirementsList)
        {
            if (card is SpellCard)
            {
                Console.WriteLine("ID: " + card.id + "  Cardtype: SpellCard  Damage: " + card.damage);
                Console.WriteLine("-------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("ID: " + card.id + "  Cardtype: MonsterCard  Damage: " + card.damage);
                Console.WriteLine("-------------------------------------------------------------------------------------");
            }
        }
    }
}
