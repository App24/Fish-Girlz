using System;
using System.Collections.Generic;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Entities;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.Entities.Items;
using SFML.Graphics;
using SFML.System;
using Fish_Girlz.Utils;
using Fish_Girlz.World;
using Fish_Girlz.Art;
using Fish_Girlz.Dialog;
using Fish_Girlz.Prompt;

namespace Fish_Girlz.States{
    public class GameState : State
    {
        UIText text;
        PlayerEntity player;
        TestEnemy test;
        DialogBox dialogBox;
        PromptBox promptBox;
        
        public override void Init()
        {
            text=new UIText(new FontInfo(AssetManager.GetFont("Arial"), 16), "Health: ",Color.White,new Vector2f(0,0));
            AddGUI(text);
            MapGenerator.InitMap();
            player=new PlayerEntity(MapGenerator.GetPlayerPos());
            AddEntity(player);
            tileEntities=MapGenerator.GetTiles();
            test=new TestEnemy(new Vector2f(256,256), new SpriteInfo(AssetManager.GetTexture("temp"), new IntRect(0,0,64,64)));
            //AddEntity(test);
            AddEntity(new TestItem(new Vector2f(256,256), new SpriteInfo(Utilities.CreateTexture(64,64, Color.Blue), new IntRect(0,0,64,64))));
            AddEntity(new TestItem(new Vector2f(256,512), new SpriteInfo(Utilities.CreateTexture(64,64, Color.Blue), new IntRect(0,0,64,64))));
            AddEntity(new TestItem(new Vector2f(512,256), new SpriteInfo(Utilities.CreateTexture(64,64, Color.Blue), new IntRect(0,0,64,64))));
            dialogBox=new DialogBox();
            promptBox=new PromptBox();
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
            List<Entity> nearbyDialogs=player.GetNearbyEntitiesWithComponent<DialogComponent, Entity>(GetEntities(), 200);
            if(nearbyDialogs.Count>0){
                promptBox.ShowPrompt("Space");
                if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Space)&&!dialogBox.Visible){
                    dialogBox.SetDialogs(nearbyDialogs[0].GetComponent<DialogComponent>().Dialogs);
                    dialogBox.Show();
                }
                dialogBox.Update();
            }else{
                promptBox.HidePrompt();
                dialogBox.Hide();
            }
        }

        public override void Pause()
        {
            
        }
    }
}