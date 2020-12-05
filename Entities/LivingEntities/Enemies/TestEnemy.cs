using System;
using Fish_Girlz.Art;
using SFML.System;

namespace Fish_Girlz.Entities{
    public class TestEnemy : EnemyEntity
    {
        public TestEnemy(Vector2f position, SpriteInfo sprite) : base(position, sprite, 2, 1)
        {
            collideDamage=false;
        }

        public override void Move()
        {

        }

        public override void Update()
        {

        }

        protected override void OnDeath()
        {

        }
    }
}