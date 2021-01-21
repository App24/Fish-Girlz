using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.States;

namespace Fish_Girlz.API.Core.Entities{
    public class TestEntity : Entity
    {
        public TestEntity() : base("test", "test", new SpriteInfo(AssetLoader.GetTexture(CoreAPIPlugin.Instance, "temp"), new SFML.Graphics.IntRect(0,0,64,64)))
        {
            AddComponent(new CollisionComponent());
        }

        internal override void Move()
        {

        }

        internal override void Update(State currentState)
        {

        }
    }
}