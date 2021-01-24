using System;
using Fish_Girlz.Art;
using Fish_Girlz.States;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.Entities{
    internal class BattleEntity : Entity
    {
        public int MaxHealth {get; protected set;}
        public int Health {get; protected set;}

        public EntityStats Stats{get;protected set;}

        public override bool ShowOnMapEditor => false;

        public BattleEntity(string id, string name, int health, int maxHealth, EntityStats stats, Texture texture, Vector2i offset) : base(id, name, texture, offset)
        {
            MaxHealth=maxHealth;
            Health=health;
            Stats=stats;
        }

        public BattleEntity(string id, string name, int health, int maxHealth, EntityStats stats, Texture texture) : this(id, name, health, maxHealth, stats, texture, new Vector2i())
        {
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