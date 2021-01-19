using System;
using Fish_Girlz.Art;
using Fish_Girlz.States;
using SFML.System;

namespace Fish_Girlz.Entities{
    public class BattleEntity : Entity
    {
        public int MaxHealth {get; protected set;}
        public int Health {get; protected set;}

        public EntityStats Stats{get;protected set;}

        public BattleEntity(Vector2f position, SpriteInfo sprite, int health, int maxHealth, EntityStats stats) : base(position, sprite)
        {
            MaxHealth=maxHealth;
            Health=health;
            Stats=stats;
        }

        public override void Move()
        {

        }

        public override void Update(State currentState)
        {

        }
    }

    public class EntityStats{

        public int Strength{get;set;}
        public int Dexterity{get;set;}
        public int Constitution{get;set;}
        public int Intelligence{get;set;}
        public int Wisdom{get;set;}
        public int Charisma{get;set;}
        public int Aggression{get;set;}

        public EntityStats(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int aggression)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            Aggression = aggression;
        }

        
    }
}