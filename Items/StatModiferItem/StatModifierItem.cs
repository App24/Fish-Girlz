using System;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public abstract class StatModifierItem : EquipableItem
    {
        public StatModifier StatModifier{get;}
        public int StatModifierAmount{get;}
        public StatModifierItem(string id, string name, Texture texture, StatModifier statModifier, int amount) : base(id, name, texture)
        {
            StatModifier=statModifier;
            StatModifierAmount=amount;
        }
    }

    public enum StatModifier{
        Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma, Aggression, None
    }
}