using System;
namespace Swe1.TestApp
{
    public class User
    {
        public User(string userName, int coins, int eloValue)
        {
            this.UserName = userName;
            this.Coins = coins;
            this.Stack = new Stack(UserName); // das kann vlt weg
            this.EloValue = eloValue;
        }
        public string UserName { get; set; }

        public Stack Stack { get; set;}
        
        public int Coins { set; get; }
        
        public int EloValue { set; get; }

        public int BuyPackages(int packagesStock)
        {
            int input;
            if (Coins >= 5)
            {
                Console.WriteLine("How many packages would you like to buy?");
                do
                {
                    Console.WriteLine("You have " + Coins + ",so you are able to buy " + Coins/5 +" package(s). For your Information we have only " + packagesStock + " packages in stock! Order: ");
                    while (!int.TryParse(Console.ReadLine(), out input))
                    {
                        Console.WriteLine("Please Enter a valid numerical value!");
                    }
                    if (input <= Coins / 5 && input > 0 && input <= packagesStock)
                    {
                        Console.WriteLine(UserName + " buys " + input + " package(s) for " + input * 5 + " coins.");
                        Stack.Generate(input);
                    }
                    else
                    {
                        Console.WriteLine("Please insert a valid number of packages.");
                    }

                } while (input > Coins / 5 || input <=0 || input > packagesStock);
                Coins -= input * 5; //Checken ob coins passen
                packagesStock -= input;
                Stack.PrintStack("normal");
            }
            else
            {
                Console.WriteLine("You have not enough Coins");
            }

            return packagesStock;
        }
    }
}

