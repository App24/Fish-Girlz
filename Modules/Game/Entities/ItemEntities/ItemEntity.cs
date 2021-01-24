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

        public ItemEntity(Item item) : base(item.ID, item.Name, item.Sprite.Texture, item.Sprite.TextureOffset)
        {
            collisionComponent=AddComponent(new CollisionComponent(item.CollisionBounds));
            collisionComponent.Collidable=false;
            collisionComponent.OnEnterCollision+=OnEnterCollision;
            this.Item=item;
        }

        CollisionBehaviour OnEnterCollision(CollisionEventArgs e){
            if(e.Other.Entity is PlayerEntity){
                PickUp((PlayerEntity)e.Other.Entity);
            }
            return CollisionBehaviour.Collision;
        }

        void PickUp(PlayerEntity player){
            int added=player.Inventory.AddItem(Item);
            if(added<=0)
                EntityEntity.ToRemove=true;
        }

        public override void Update(State currentState)
        {

        }

        public override void Move()
        {

        }
    }
}