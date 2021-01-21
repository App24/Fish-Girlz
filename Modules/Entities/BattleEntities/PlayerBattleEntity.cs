using System;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.States;
using Fish_Girlz.Systems;

namespace Fish_Girlz.Entities{
    public class PlayerBattleEntity : BattleEntity
    {
        private SpriteSheet spriteSheet;
        Animation idle;
        Animation attack;
        Animation currentAnimation;

        public PlayerBattleEntity(int health, int maxHealth, EntityStats stats) : base("battle_player", "battle_player", AssetManager.GetSpriteSheet("dominique").GetSpriteInfo(0, 0), health, maxHealth, stats)
        {
            spriteSheet = AssetManager.GetSpriteSheet("dominique");
            SetupAnimations();
            currentAnimation = idle;
        }

        private void SetupAnimations()
        {
            attack = new Animation(12, new IntRect[] {
                spriteSheet.GetTextureRect(0,17),
                spriteSheet.GetTextureRect(1,17),
                spriteSheet.GetTextureRect(2,17),
                spriteSheet.GetTextureRect(3,17),
                spriteSheet.GetTextureRect(4,17),
                spriteSheet.GetTextureRect(5,17),
                spriteSheet.GetTextureRect(6,17),
                spriteSheet.GetTextureRect(7,17),
                spriteSheet.GetTextureRect(8,17),
                spriteSheet.GetTextureRect(9,17),
                spriteSheet.GetTextureRect(10,17),
                spriteSheet.GetTextureRect(11,17),
                spriteSheet.GetTextureRect(12,17),
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

        internal override void Update(State currentState)
        {
            base.Update(currentState);
            if (currentAnimation.Update())
            {
                Sprite = spriteSheet.GetSpriteInfo(currentAnimation.GetCurrentIntRect());
            }
        }
    }
}