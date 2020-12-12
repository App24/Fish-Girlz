using System;
using Fish_Girlz.Art;
using Fish_Girlz.Inventory.Items;
using Fish_Girlz.States;
using SFML.System;

namespace Fish_Girlz.Entities.Items{
    public class BasicItemEntity : ItemEntity
    {
        public BasicItemEntity(Vector2f position, SpriteInfo sprite, Item item) : base(position, sprite, item)
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