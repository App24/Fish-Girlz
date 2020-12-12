using System;

namespace Fish_Girlz.Inventory.Items{
    public class BasicItem : Item
    {
        public BasicItem(string name, uint maxStack=64) : base(name, maxStack)
        {
        }
    }
}