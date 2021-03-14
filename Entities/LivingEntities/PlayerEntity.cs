using Fish_Girlz.Systems;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Entities{
    public class PlayerEntity : LivingEntity
    {
        public PlayerEntity(Vector2f position) : base(20, position, AssetManager.GetSpritesheet("Dominique Spritesheet").GetTexture(0,0))
        {
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