using System;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using Fish_Girlz.Entities;
using Fish_Girlz.Items;
using Fish_Girlz.Entities.Components;
using SFML.System;
using Fish_Girlz.States;

namespace Fish_Girlz.Entities.Items{
    public class ItemEntity : Entity
    {
        CollisionComponent collisionComponent;

        public Item Item{get;}

        public ItemEntity(Item item) : base(item.ID, item.Name, item.Sprite)
        {
            collisionComponent=AddComponent(new CollisionComponent());
            collisionComponent.Collidable=false;
            collisionComponent.OnCollision+=OnCollision;
            collisionComponent.CollisionBounds=item.CollisionBounds;
            this.Item=item;
        }

        void OnCollision(object sender, CollisionEventArgs e){
            if(e.Other.Entity is PlayerEntity){
                PickUp((PlayerEntity)e.Other.Entity);
            }
        }

        void PickUp(PlayerEntity player){
            int added=player.Inventory.AddItem(Item);
            if(added<=0)
                EntityEntity.ToRemove=true;
        }

        internal override void Update(State currentState)
        {

        }

        internal override void Move()
        {

        }
    }
}