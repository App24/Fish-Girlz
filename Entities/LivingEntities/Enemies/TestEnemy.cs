using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.States;
using SFML.System;

namespace Fish_Girlz.Entities{
    public class TestEnemy : EnemyEntity
    {
        public TestEnemy(Vector2f position, SpriteInfo sprite) : base(position, sprite, 2, 1)
        {
            
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