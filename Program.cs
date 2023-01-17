using MTCGame.DAL;
using MTCGame.Models;
using MTCGame.BLL;
using System.Net;

namespace MTCGame
{
    class Program
{
    static void Main(string[] args)
    {

        string input;
        string username;
        string password;
        string tradeinput;
        int packagesStock = 8;
        Console.WriteLine("Welcome to Monster Trading Crads!");
        UserPlayer user1 = new UserPlayer("User1", 20, 100); // Coins müssen von der Datenbank ausgelesen werden
        UserPlayer user2 = new UserPlayer("User2", 20, 100); // EloValues am Anfang 100 anschließend aus Datenbank auslesen
        ScoreBoard scoreBoard = new ScoreBoard();
        scoreBoard.AddUser(user1); //Dies müsste in eine eigene Funktion wenn ein User angelegt wird.
        scoreBoard.AddUser(user2);
        Store tradingStore = new Store();
        do
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("#################################################################################################################################################");
            Console.WriteLine("## (B)uy, (F)ight, (C)hoose-->BattleCards, (T)rade, (S)how stacks, (SC)oreboard, (P)roduce package, (ST)ShowStore, (L)ogin, (R)egister, (E)xit ##");
            Console.WriteLine("#################################################################################################################################################");
            Console.WriteLine("Name: " + user1.UserName);
            Console.WriteLine("Coins: " + user1.Coins);
            //editable profilepage noch kreiren
            do
            {
                input = Console.ReadLine();
                if (input != "B" && input != "F" && input != "E" && input != "C" 
                    && input != "S" && input != "SC" && input != "L" && input != "R" && input != "T" && input != "ST")
                {
                    Console.WriteLine("Incorrect Input! Please try again!");
                }
            } while (input != "B" && input != "F" && input != "E" && input != "C" 
                     && input != "S" && input != "SC" && input != "L" && input != "R" && input != "T" && input != "ST");

            switch (input)
            {

                case "B":
                    //Buy packages
                    packagesStock = user1.BuyPackages(packagesStock);
                    packagesStock = user2.BuyPackages(packagesStock);
                    break;

                case "C":
                    //Choose Battlestack
                    if (user1.Stack.NormalStack != null)
                    {
                        user1.Stack.ChooseForBattle();
                        user1.Stack.PrintStack("battle"); 
                    }
                    else
                    {
                        Console.WriteLine("Please aquire Cards");
                    }

                    if (user2.Stack.NormalStack != null)
                    {
                        user2.Stack.ChooseForBattle();
                        user2.Stack.PrintStack("battle");
                    }
                    else
                    {
                        Console.WriteLine("Please aquire Cards");
                    }
                    break;

                case "F":
                    //Fight
                    if (user1.Stack.BattleStack != null &&
                        user2.Stack.BattleStack != null && user1.Stack.BattleStack.Count == 4  &&
                        user2.Stack.BattleStack.Count == 4) //Oder es sind keine 4 Karten drin.
                    {
                        Console.WriteLine("Let the Battle begin");
                        BattleGround battle = new BattleGround(user1, user2);
                        battle.GreatBattle();
                    }
                    else
                    {
                        Console.WriteLine(
                            "Please select your BattleStack! You may have too many or not enough cards with you!");
                    }

                    break;
                
                case "S":
                    //Show stack
                    if (user1.Stack.NormalStack != null)
                    {
                        user1.Stack.PrintStack("normal");
                    }
                    else
                    {
                        Console.WriteLine("Please aquire Cards");
                    }

                    if (user1.Stack.BattleStack != null)
                    {
                        user1.Stack.PrintStack("Battle");
                    }
                    else
                    {
                        Console.WriteLine("Your Battlestack is empty");
                    }
                    break;
                
                case "T":
                    //Trading
                    Console.WriteLine("(S)ell or (B)uy");
                    tradeinput = Console.ReadLine(); //Falsche Eingaben überprüfen
                    if (tradeinput == "S")
                    {
                        tradingStore.Seller.Add(user1); //Hier natürlich anpassen auf alle user // if not already exists
                        tradingStore.ActiveSeller = user1;
                        Console.WriteLine("SellerAccount created!");
                        tradingStore.Sell();
                    }
                    else if (tradeinput == "B")
                    {
                        tradingStore.ActiveCostumer = user2; //Hier natürlich anpassen auf alle user // if not already exists
                        tradingStore.Buy();
                    }
                    break;
                
                case "ST": //nullabfragen
                    //Show Storeavailabilities
                    tradingStore.PrintStore();
                    break;
                
                case "SC": //nullabfragen
                    //Show Scoreboard
                    scoreBoard.SortScores();
                    scoreBoard.PrintScoreBoard();
                    break;
                
                case "L":
                    //Login
                    Console.WriteLine("Username: ");
                    username = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    password = Console.ReadLine();
                    break;
                
                case "R":
                    //Register
                    Console.WriteLine("Username: "); //has to be unique
                    username = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    password = Console.ReadLine();
                    break;

                case "E":
                    //Exit
                    Console.WriteLine("Program exit");
                    System.Environment.Exit(1);
                    break;
            }
        } while (input != "E");
    }
}
}