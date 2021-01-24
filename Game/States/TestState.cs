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
using Fish_Girlz.Systems;

namespace Fish_Girlz.States{
    public class TestState : State
    {
        UIText healthText, manaText;
        GUIGroup hudGroup;
        EntityEntity player;
        DialogBox dialogBox;
        PromptBox promptBox;
        
        internal override void Init()
        {
            hudGroup=new GUIGroup();
            healthText=hudGroup.AddGUI(new UIText(new FontInfo(AssetManager.GetFont("Arial"), 16), "Health: ",Color.White,new Vector2f(0,0)));
            manaText=hudGroup.AddGUI(new UIText(new FontInfo(AssetManager.GetFont("Arial"), 16), "Mana: ", Color.White, new Vector2f(0,18)));
            hudGroup.AddGUIs(this);
            AddGUI(healthText);
            MapGenerator.InitMap("map2");
            player=new EntityEntity(MapGenerator.GetPlayerPos(), Entity.GetEntity("player"));
            ((PlayerEntity)player.Entity).Init();
            AddEntity(player);
            tileEntities=MapGenerator.GetTileEntities();
            itemEntities=MapGenerator.GetItemEntities();
            entities=MapGenerator.GetEntityEntities();

            dialogBox=new DialogBox();
            promptBox=new PromptBox();
        }

        internal override void Update()
        {
            Camera.TargetEntity(player);
            healthText.Text=$"Health: {((PlayerEntity)player.Entity).Health}";
            manaText.Text=$"Mana: {((PlayerEntity)player.Entity).Mana}";
        }

        internal override void HandleInput()
        {
            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Escape)){
                StateMachine.AddState(new PauseState(), false);
            }
            List<EntityEntity> nearbyDialogs=player.GetNearbyEntitiesWithComponent<DialogComponent, EntityEntity>(GetEntities(), 3.125f);
            if(nearbyDialogs.Count>0){
                promptBox.ShowPrompt(InputManager.KeyCodeToString(SFML.Window.Keyboard.Key.Space));
                if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Space)&&!dialogBox.Visible){
                    dialogBox.SetDialogs(nearbyDialogs[0].GetComponent<DialogComponent>().Dialogs);
                    dialogBox.Show();
                }
                dialogBox.Update();
            }else{
                promptBox.HidePrompt();
                dialogBox.Hide();
            }
            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.E)||InputManager.IsJoystickButtonPressed(0)){
                ((PlayerEntity)player.Entity).Inventory.ToggleInventory();
            }
        }

        internal override void Pause()
        {
            
        }
    }
}