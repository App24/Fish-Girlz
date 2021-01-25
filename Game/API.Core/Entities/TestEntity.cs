using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.States;
using Fish_Girlz.Utils;
using Fish_Girlz.Systems;

namespace Fish_Girlz.API.Core.Entities{
    public class TestEntity : LivingEntity
    {
        CollisionComponent collisionComponent;

        public TestEntity() : base("test", "test", 10, AssetLoader.GetTexture(CoreAPIPlugin.Instance, "temp"))
        {
            collisionComponent=AddComponent(new CollisionComponent(new SFML.Graphics.IntRect(0,0,Sprite.Bounds.Width, Sprite.Bounds.Height)));
            collisionComponent.OnEnterCollision+=AddComponent(new BattleComponent()).OnEnterCollision;
        }

        public override void Move()
        {

        }

        public override void Update(State currentState)
        {

        }

        protected override void OnDeath()
        {
            
        }
    }
}