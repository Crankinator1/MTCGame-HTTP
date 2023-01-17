
namespace MTCGame
{
    public abstract class GameCard
    {

        public string elementtype { get; set; }

        public int damage { get; set; }

        public  string name { get; set; }
        
        public int id { get; set; }
        
        public string monstertype { get; set; }
        
        public string owner { get; set; }
        
        public  int sellID { get; set; }
    }
}