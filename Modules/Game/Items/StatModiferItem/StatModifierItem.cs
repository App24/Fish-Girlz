using System;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Items{
    public abstract class StatModifierItem : EquipableItem
    {
        public StatModifier StatModifier{get;}
        public int StatModifierAmount{get;}
        public StatModifierItem(string id, string name, Texture texture, StatModifier statModifier, int amount) : this(id, name, texture, new Vector2i(), statModifier, amount)
        {
        }
        
        public StatModifierItem(string id, string name, Texture texture, Vector2i offset, StatModifier statModifier, int amount) : base(id, name, texture)
        {
            StatModifier=statModifier;
            StatModifierAmount=amount;
        }
    }

    public enum StatModifier{
        Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma, Aggression, None
    }
}