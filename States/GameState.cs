using System;
using System.Collections.Generic;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Entities;
using SFML.Graphics;
using SFML.System;
using Fish_Girlz.Utils;
using Fish_Girlz.Art;

namespace Fish_Girlz.States{
    public class GameState : State
    {
        UIText text;
        Player player;
        TileEntity staticEntity, staticEntity2;

        public override void Init()
        {
            text=new UIText(new FontInfo(AssetManager.GetFont("Arial"), 16), "LMAO",Color.White,new Vector2f(0,0));
            guis.Add(text);
            player=new Player(new Vector2f());
            entities.Add(player);
            staticEntity=new TileEntity(new Vector2f(120,120), (SpriteInfo)new LayeredSprite(AssetManager.GetTexture("temp")), true);
            staticEntity2=new TileEntity(new Vector2f(420,120), (SpriteInfo)new LayeredSprite(AssetManager.GetTexture("temp")), false);
            entities.Add(staticEntity);
            entities.Add(staticEntity2);
        }

        public override void Update()
        {
            player.Update();
            CheckCollisions();
            Camera.TargetEntity(player);
        }

        public override void HandleInput()
        {
            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Escape)){
                StateMachine.AddState(new PauseState(), false);
            }
        }
    }
}