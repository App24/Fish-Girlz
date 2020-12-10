using System;
using System.Collections.Generic;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Entities;
using Fish_Girlz.Entities.Tiles;
using SFML.Graphics;
using SFML.System;
using Fish_Girlz.Utils;
using Fish_Girlz.World;
using Fish_Girlz.Art;
using Fish_Girlz.Dialog;

namespace Fish_Girlz.States{
    public class GameState : State
    {
        UIText text;
        PlayerEntity player;
        TestEnemy test;

        DialogBox dialogBox;
        
        public override void Init()
        {
            text=new UIText(new FontInfo(AssetManager.GetFont("Arial"), 16), "Health: ",Color.White,new Vector2f(0,0));
            AddGUI(text);
            MapGenerator.InitMap();
            player=new PlayerEntity(MapGenerator.GetPlayerPos());
            AddEntity(player);
            tileEntities=MapGenerator.GetTiles();
            test=new TestEnemy(new Vector2f(256,256), new SpriteInfo(AssetManager.GetTexture("temp"), new IntRect(0,0,64,64)));
            AddEntity(test);
            dialogBox=new DialogBox();
        }

        public override void Update()
        {
            Camera.TargetEntity(player);
            text.Text=$"Health: {player.Health}";
        }

        public override void HandleInput()
        {
            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Escape)){
                StateMachine.AddState(new PauseState(), false);
            }
            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Space)){
                test.Damage(1);
            }
        }

        public override void Pause()
        {
            
        }

        public override PlayerEntity GetPlayer()
        {
            return player;
        }

        public override DialogBox GetDialogBox()
        {
            return dialogBox;
        }
    }
}