using System;
using Fish_Girlz.Art;
using Fish_Girlz.States;
using SFML.System;
using Fish_Girlz.Inventory.Items;

namespace Fish_Girlz.Entities.Items{
    public class TestItem : ItemEntity
    {
        public TestItem(Vector2f position, SpriteInfo sprite) : base(position, sprite, Item.ITEM_TEST)
        {
        }

        public override void Move()
        {

        }

        public override void Update(State currentState)
        {

        }
    }
}