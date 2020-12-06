using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.Entities{
    public class ArrowProjectile : ProjectileEntity
    {
        private float speed;

        private Clock aliveClock;

        public ArrowProjectile(Vector2f position, int damage, LivingEntity originEntity, float speed) : base(position, new SpriteInfo(Utilities.CreateTexture(32,16,Color.White), new IntRect(0,0,32,16)), damage, originEntity)
        {
            this.speed=speed;
            aliveClock=new Clock();
        }

        public override void Move()
        {
            Speed+=new Vector2f(speed, 0);
        }

        public override void Update(State currentState)
        {
            if(aliveClock.ElapsedTime.AsMilliseconds()>=1500){
                ToRemove=true;
            }
        }
    }
}