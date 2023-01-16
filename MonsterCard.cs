

namespace Swe1.TestApp
{
    public class MonsterCard : GameCard
    {
        public MonsterCard(string elementtype, int damage, string name, int id, string monstertype, string owner)
        {
            this.elementtype = elementtype;
            this.damage = damage;
            this.name = name;
            this.id = id;
            this.monstertype = monstertype;
            this.owner = owner;
        }
    }
}
