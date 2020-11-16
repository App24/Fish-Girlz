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

namespace Fish_Girlz.States{
    public class GameState : State
    {
        UIText text;
        Player player;

        public override void Init()
        {
            text=new UIText(new FontInfo(AssetManager.GetFont("Arial"), 16), "LMAO",Color.White,new Vector2f(0,0));
            guis.Add(text);
            MapGenerator.InitMap();
            player=new Player(MapGenerator.GetPlayerPos());
            entities.Add(player);
            tiles=MapGenerator.GetTiles();
        }

        public override void Update()
        {
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