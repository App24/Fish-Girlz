using System;
using Fish_Girlz.Art;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Items{
    public abstract class EquipableItem : Item
    {
        public EquipableItem(string id, string name, Texture texture) : base(id, name, texture, 1)
        {
        }
        public EquipableItem(string id, string name, Texture texture, Vector2i offset) : base(id, name, texture, offset, 1)
        {
        }
    }
}