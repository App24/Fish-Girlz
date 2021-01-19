using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Inventory;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using Fish_Girlz.Entities.Components;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using Fish_Girlz.Systems;

namespace Fish_Girlz.Entities
{
    public class PlayerEntity : LivingEntity
    {
        private SpriteSheet spriteSheet;
        float speed = 200f;
        Animation walkForward, walkBackward, walkLeft, walkRight;
        Animation idle;
        Animation currentAnimation;
        (bool, bool) walking;
        protected CollisionComponent collisionComponent;

        public PlayerInventory Inventory{get;}

        public PlayerEntity(Vector2f position) : base(position, AssetManager.GetSpriteSheet("dominique").GetSpriteInfo(0, 0), 20)
        {
            spriteSheet = AssetManager.GetSpriteSheet("dominique");
            SetupAnimations();
            currentAnimation = walkForward;
            Sprite.Layer=10000;
            collisionComponent=AddComponent(new CollisionComponent());
            collisionComponent.CollisionBounds=new IntRect(20,14,44,63);
            Inventory=new PlayerInventory(player:this);
        }

        private void SetupAnimations()
        {
            walkForward = new Animation(12, new IntRect[]{
                spriteSheet.GetTextureRect(0, 8),
                spriteSheet.GetTextureRect(1, 8),
                spriteSheet.GetTextureRect(2, 8),
                spriteSheet.GetTextureRect(3, 8),
                spriteSheet.GetTextureRect(4, 8),
                spriteSheet.GetTextureRect(5, 8),
                spriteSheet.GetTextureRect(6, 8),
                spriteSheet.GetTextureRect(7, 8),
                spriteSheet.GetTextureRect(8, 8),
            });
            walkBackward = new Animation(12, new IntRect[]{
                spriteSheet.GetTextureRect(0, 10),
                spriteSheet.GetTextureRect(1, 10),
                spriteSheet.GetTextureRect(2, 10),
                spriteSheet.GetTextureRect(3, 10),
                spriteSheet.GetTextureRect(4, 10),
                spriteSheet.GetTextureRect(5, 10),
                spriteSheet.GetTextureRect(6, 10),
                spriteSheet.GetTextureRect(7, 10),
                spriteSheet.GetTextureRect(8, 10),
            });
            walkRight = new Animation(12, new IntRect[]{
                spriteSheet.GetTextureRect(0, 11),
                spriteSheet.GetTextureRect(1, 11),
                spriteSheet.GetTextureRect(2, 11),
                spriteSheet.GetTextureRect(3, 11),
                spriteSheet.GetTextureRect(4, 11),
                spriteSheet.GetTextureRect(5, 11),
                spriteSheet.GetTextureRect(6, 11),
                spriteSheet.GetTextureRect(7, 11),
                spriteSheet.GetTextureRect(8, 11),
            });
            walkLeft = new Animation(12, new IntRect[]{
                spriteSheet.GetTextureRect(0, 9),
                spriteSheet.GetTextureRect(1, 9),
                spriteSheet.GetTextureRect(2, 9),
                spriteSheet.GetTextureRect(3, 9),
                spriteSheet.GetTextureRect(4, 9),
                spriteSheet.GetTextureRect(5, 9),
                spriteSheet.GetTextureRect(6, 9),
                spriteSheet.GetTextureRect(7, 9),
                spriteSheet.GetTextureRect(8, 9),
            });
            idle = new Animation(12, new IntRect[] {
                spriteSheet.GetTextureRect(0,0),
                spriteSheet.GetTextureRect(1,0),
                spriteSheet.GetTextureRect(2,0),
                spriteSheet.GetTextureRect(3,0),
                spriteSheet.GetTextureRect(4,0),
                spriteSheet.GetTextureRect(5,0),
                spriteSheet.GetTextureRect(6,0),
            });
        }

        protected override void OnDeath()
        {

        }

        public override void Update(State currentState)
        {
            if (currentAnimation.Update())
            {
                Sprite = spriteSheet.GetSpriteInfo(currentAnimation.GetCurrentIntRect());
            }
            Inventory.Update();
        }

        public override void Move()
        {
            if (InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.W)||InputManager.AxisMovement(Joystick.Axis.Y)<-50)
            {
                Speed += new Vector2f(0, -speed);
                currentAnimation = walkForward;
                walking.Item1 = true;
            }
            else if (InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.S)||InputManager.AxisMovement(Joystick.Axis.Y)>50)
            {
                Speed += new Vector2f(0, speed);
                currentAnimation = walkBackward;
                walking.Item1 = true;
            }
            else
            {
                walking.Item1 = false;
            }

            if (InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.A)||InputManager.AxisMovement(Joystick.Axis.X)<-50)
            {
                Speed += new Vector2f(-speed, 0);
                currentAnimation = walkLeft;
                walking.Item2 = true;
            }
            else if (InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.D)||InputManager.AxisMovement(Joystick.Axis.X)>50)
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
    }
}