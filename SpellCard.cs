

namespace MTCGame
{
    public class SpellCard : GameCard
    {
        public SpellCard(string elementtype, int damage, string name, int id, string owner)
        {
            this.elementtype = elementtype;
            this.damage = damage;
            this.name = name;
            this.id = id;
            this.owner = owner;
        }

    }
}