using System;
using Fish_Girlz.Utils;
using Fish_Girlz.Battle;
using Fish_Girlz.Entities;
using Fish_Girlz.Art;
using SFML.System;

namespace Fish_Girlz.States{
    public class BattleState : State
    {
        public BattleData battleData;

        private Vector2f enemy0Pos=new Vector2f(200,300);
        private Vector2f enemy1Pos=new Vector2f();
        private Vector2f enemy2Pos=new Vector2f();

        private Vector2f player0Pos=new Vector2f(800,300);
        private Vector2f player1Pos=new Vector2f();
        private Vector2f player2Pos=new Vector2f();

        public override void Init()
        {
            Camera.ResetView();
            if(battleData.Enemy0!=null){
                EnemyEntity enemy=battleData.Enemy0;
                AddEntity(new BattleEntity(enemy0Pos, enemy.Sprite, enemy.Health, enemy.MaxHealth, enemy.Stats));
            }
            if(battleData.Enemy1!=null){
                EnemyEntity enemy=battleData.Enemy1;
                AddEntity(new BattleEntity(enemy0Pos, enemy.Sprite, enemy.Health, enemy.MaxHealth, enemy.Stats));
            }
            if(battleData.Enemy2!=null){
                EnemyEntity enemy=battleData.Enemy2;
                AddEntity(new BattleEntity(enemy0Pos, enemy.Sprite, enemy.Health, enemy.MaxHealth, enemy.Stats));
            }

            if(battleData.Player!=null){
                PlayerEntity player=battleData.Player;
                AddEntity(new PlayerBattleEntity(player0Pos, player.Health, player.MaxHealth, player.Stats));
            }
        }

        public override void HandleInput()
        {

        }

        public override void Update()
        {
            
        }

        public override void Remove()
        {
            
        }
    }
}