namespace MTCGame
{
    public class LiveBoard
    {
        public LiveBoard(int round)
        {
            this.Round = round;
        }
        public int Round;
        //public string fightType;
        //public int scoreHome;
        //public int scoreGuest;

        public void Printround()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Round: " + Round);
            Console.WriteLine("---------------------------------------------");
        }
    }
}

