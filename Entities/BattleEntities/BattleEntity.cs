using System;
using Fish_Girlz.Art;
using Fish_Girlz.States;
using SFML.System;

namespace Fish_Girlz.Entities{
    public class BattleEntity : Entity
    {
        public int MaxHealth {get; protected set;}
        public int Health {get; protected set;}

        public BattleEntity(Vector2f position, SpriteInfo sprite, int health, int maxHealth) : base(position, sprite)
        {
            MaxHealth=maxHealth;
            Health=health;
        }

        public override void Move()
        {

        }

        public override void Update(State currentState)
        {

        }
    }
}