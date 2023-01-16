namespace Swe1.TestApp
{
    public class ScoreBoard
    {
        public ScoreBoard(/*List<int> Elo_values, int wins, int defeats*/)
        {
            //this.Elo_values = Elo_values;
            //this.wins = wins;
            //this.defeats = defeats;
            Userstats = new List<User>();
        }
        public List <User> Userstats;

        public void SortScores()
        {
            Userstats = Userstats.OrderByDescending(o=>o.EloValue).ToList();
        }

        public void PrintScoreBoard()
        {
            int count = 1;
            Console.WriteLine("---------------------------------------------");
            foreach (User user in Userstats)
            {
                Console.WriteLine(count + ".  Name: " + user.UserName + "    " + user.EloValue + "    Cards: " 
                                  + user.Stack.NormalStack.Count); //Was bei Gleichstand??
                count++;
            }
            Console.WriteLine("---------------------------------------------");
        }

        public void AddUser(User user)
        {
            Userstats.Add(user);
        }
        // Überlegen ob user die values erhält, da username natürlich mitangegeben werden soll
        //Dann würde die Klasse wegfallen
        //public int wins;
        //public int defeats;
    }
}

