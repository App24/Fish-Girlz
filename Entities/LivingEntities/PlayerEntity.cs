using Fish_Girlz.Systems;
using SFML.Graphics;
using SFML.System;
using Fish_Girlz.Art;

namespace Fish_Girlz.Entities{
    public class PlayerEntity : LivingEntity
    {
        Spritesheet spritesheet;

        Animation currentAnimation;
        Animation idle;
        Animation walkForward, walkBackward, walkLeft, walkRight;
        float speed = 200f;
        (bool, bool) walking;

        public PlayerEntity(Vector2f position) : base(20, position, AssetManager.GetSpritesheet("Dominique Spritesheet").GetTexture(0,0))
        {
            spritesheet=AssetManager.GetSpritesheet("Dominique Spritesheet");
            LoadAnimations();
            currentAnimation=idle;
        }

        void LoadAnimations(){
            idle=new Animation(12,
                spritesheet.GetTexture(0,0),
                spritesheet.GetTexture(1,0),
                spritesheet.GetTexture(2,0),
                spritesheet.GetTexture(3,0),
                spritesheet.GetTexture(4,0),
                spritesheet.GetTexture(5,0),
                spritesheet.GetTexture(6,0)
            );
            walkForward = new Animation(12,
                spritesheet.GetTexture(0, 8),
                spritesheet.GetTexture(1, 8),
                spritesheet.GetTexture(2, 8),
                spritesheet.GetTexture(3, 8),
                spritesheet.GetTexture(4, 8),
                spritesheet.GetTexture(5, 8),
                spritesheet.GetTexture(6, 8),
                spritesheet.GetTexture(7, 8),
                spritesheet.GetTexture(8, 8)
            );
            walkBackward = new Animation(12,
                spritesheet.GetTexture(0, 10),
                spritesheet.GetTexture(1, 10),
                spritesheet.GetTexture(2, 10),
                spritesheet.GetTexture(3, 10),
                spritesheet.GetTexture(4, 10),
                spritesheet.GetTexture(5, 10),
                spritesheet.GetTexture(6, 10),
                spritesheet.GetTexture(7, 10),
                spritesheet.GetTexture(8, 10)
            );
            walkRight = new Animation(12, 
                spritesheet.GetTexture(0, 11),
                spritesheet.GetTexture(1, 11),
                spritesheet.GetTexture(2, 11),
                spritesheet.GetTexture(3, 11),
                spritesheet.GetTexture(4, 11),
                spritesheet.GetTexture(5, 11),
                spritesheet.GetTexture(6, 11),
                spritesheet.GetTexture(7, 11),
                spritesheet.GetTexture(8, 11)
            );
            walkLeft = new Animation(12,
                spritesheet.GetTexture(0, 9),
                spritesheet.GetTexture(1, 9),
                spritesheet.GetTexture(2, 9),
                spritesheet.GetTexture(3, 9),
                spritesheet.GetTexture(4, 9),
                spritesheet.GetTexture(5, 9),
                spritesheet.GetTexture(6, 9),
                spritesheet.GetTexture(7, 9),
                spritesheet.GetTexture(8, 9)
            );
        }

        public override void Move()
        {
            if (InputManager.IsUpHeld())
            {
                Speed += new Vector2f(0, -speed);
                currentAnimation = walkForward;
                walking.Item1 = true;
            }
            else if (InputManager.IsDownHeld())
            {
                Speed += new Vector2f(0, speed);
                currentAnimation = walkBackward;
                walking.Item1 = true;
            }
            else
            {
                walking.Item1 = false;
            }

            if (InputManager.IsLeftHeld())
            {
                Speed += new Vector2f(-speed, 0);
                currentAnimation = walkLeft;
                walking.Item2 = true;
            }
            else if (InputManager.IsRightHeld())
            {
                Speed += new Vector2f(speed, 0);
                currentAnimation = walkRight;
                walking.Item2 = true;
            }
            else
            {
                walking.Item2 = false;
            }

            if (!walking.Item1 && !walking.Item2)
            {
                currentAnimation = idle;
            }
        }

        public override void Update()
        {
            if(currentAnimation.Update()){
                Texture=currentAnimation.GetCurrentFrame();
            }
        }

        protected override void OnDeath()
        {

        }
    }
}