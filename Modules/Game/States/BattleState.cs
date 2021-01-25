using System;
using Fish_Girlz.Utils;
using Fish_Girlz.Battle;
using Fish_Girlz.Entities;
using Fish_Girlz.Art;
using SFML.System;

namespace Fish_Girlz.States{
    public class BattleState : State
    {
        internal BattleData battleData;

        private Vector2f enemy0Pos=new Vector2f(200,300);
        private Vector2f enemy1Pos=new Vector2f(150,150);
        private Vector2f enemy2Pos=new Vector2f(150,450);

        private Vector2f player0Pos=new Vector2f(800,300);
        private Vector2f player1Pos=new Vector2f();
        private Vector2f player2Pos=new Vector2f();

        internal override void Init()
        {
            Camera.ResetView();
            if(battleData.Enemy0!=null){
                LivingEntity enemy=battleData.Enemy0;
                AddEntity(new EntityEntity(enemy0Pos, new BattleEntity(enemy.ID, enemy.Name, enemy.Health, enemy.MaxHealth, enemy.Stats, enemy.Sprite.Texture, enemy.Sprite.TextureOffset)));
            }
            if(battleData.Enemy1!=null){
                LivingEntity enemy=battleData.Enemy1;
                AddEntity(new EntityEntity(enemy1Pos, new BattleEntity(enemy.ID, enemy.Name, enemy.Health, enemy.MaxHealth, enemy.Stats, enemy.Sprite.Texture, enemy.Sprite.TextureOffset)));
            }
            if(battleData.Enemy2!=null){
                LivingEntity enemy=battleData.Enemy2;
                AddEntity(new EntityEntity(enemy2Pos, new BattleEntity(enemy.ID, enemy.Name, enemy.Health, enemy.MaxHealth, enemy.Stats, enemy.Sprite.Texture, enemy.Sprite.TextureOffset)));
            }

            if(battleData.Player!=null){
                PlayerEntity player=battleData.Player;
                AddEntity(new EntityEntity(player0Pos, new PlayerBattleEntity(player.Health, player.MaxHealth, player.Stats)));
            }
        }

        internal override void HandleInput()
        {

        }

        internal override void Update()
        {
            
        }

        internal override void Remove()
        {
            
        }
    }
}