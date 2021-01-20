using System;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using Fish_Girlz.Audio;
using SFML.Window;
using Fish_Girlz.Items;
using Fish_Girlz.Entities;
using Fish_Girlz.Systems;
using Fish_Girlz.API;
using Fish_Girlz.Localisation;

namespace Fish_Girlz
{
    public class Program
    {
        public static string Version="Alpha 1.0.0";

        public static void Main(string[] args)
        {
            #if DEBUG
                Logger.Debug=true;
            #endif
            PluginLoader.AddPlugin(new Plugin(new Fish_Girlz.API.Core.CoreAPIPlugin(), new Mod("Core", "core", "App24", new API.Version(1,0,0)), Utilities.ExecutingFolder));
            Logger.InitLogger();

            LocalisationLoader.LoadDefault();

            PluginLoader.LoadPlugins();

            Utils.AssetLoader.LoadAssets();

            DisplayManager.CreateWindow(1280,720, "Fish Girlz: Mermaid Adventures");

            InputManager.InitInputManager();

            Tiles.TileLoader.LoadTiles();
            // Items.ItemLoader.LoadItems();
            PluginLoader.LoadItems();
            
            StateMachine.AddState(new MainMenuState());

            // if(!Items.ItemLoader.Loaded){
            //     Logger.Log("Failed to load items or entities", Logger.LogLevel.Error);
            //     throw new Exception("Failed to load items or entities");
            // }

            while(DisplayManager.Window.IsOpen){
                StateMachine.ProcessStateChanges();
                Delta.UpdateDelta();
                Joystick.Update();

                DisplayManager.Window.DispatchEvents();

                if(InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.LAlt)&&InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.F4)){
                    DisplayManager.Close();
                }

                if (!StateMachine.IsEmpty)
                {
                    Update();
                }

                DisplayManager.Window.Clear();
                if (!StateMachine.IsEmpty)
                    RenderSystem.Render();
                DisplayManager.Window.Display();

                InputManager.ResetInputManager();
            }

            DisplayManager.Window.Dispose();
        }

        static void Update(){
            StateMachine.ActiveState.StateLogic();
            LogicSystem.Update();
            if(StateMachine.IsEmpty) return;
            CollisionSystem.CheckCollisions();
            
            StateMachine.ActiveState.Update();
            StateMachine.ActiveState.HandleInput();
        }
    }
}
