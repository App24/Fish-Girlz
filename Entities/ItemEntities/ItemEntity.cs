using System;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using Fish_Girlz.Entities;
using Fish_Girlz.Inventory.Items;
using Fish_Girlz.Entities.Components;
using SFML.System;

namespace Fish_Girlz.Entities.Items{
    public abstract class ItemEntity : Entity
    {
        CollisionComponent collisionComponent;

        Item item;

        public ItemEntity(Vector2f position, SpriteInfo sprite, Item item) : base(position, sprite)
        {
            collisionComponent=AddComponent(new CollisionComponent());
            collisionComponent.Collidable=false;
            collisionComponent.OnCollision+=OnCollision;
            this.item=item;
        }

        void OnCollision(object sender, CollisionEventArgs e){
            if(e.Other is PlayerEntity){
                PickUp((PlayerEntity)e.Other);
            }
        }

        void PickUp(PlayerEntity player){
            Console.WriteLine(player.Inventory.ToString());
            bool added=player.Inventory.AddItem(item);
            if(added)
                ToRemove=true;
            Console.WriteLine(player.Inventory.ToString());
        }
    }
}