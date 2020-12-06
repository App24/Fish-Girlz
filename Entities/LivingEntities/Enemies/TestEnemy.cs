using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.States;
using SFML.System;

namespace Fish_Girlz.Entities{
    public class TestEnemy : EnemyEntity
    {
        Clock shootClock;

        public TestEnemy(Vector2f position, SpriteInfo sprite) : base(position, sprite, 2, 1)
        {
            collideDamage=false;
            shootClock=new Clock();
        }

        public override void Move()
        {

        }

        public override void Update(State currentState)
        {
            if(shootClock.ElapsedTime.AsMilliseconds()>=1000){
                currentState.AddEntity(new ArrowProjectile(Position, damage, this, 5));
                shootClock.Restart();
            }
        }

        protected override void OnDeath()
        {

        }
    }
}