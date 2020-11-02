using System;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using Fish_Girlz.Audio;

namespace Fish_Girlz
{
    public class Program
    {
        public static string Version="Alpha 1.0.0";

        public static void Main(string[] args)
        {
            AssetLoader.LoadAssets();
            DisplayManager.CreateWindow(1280,720, "Fish Girlz: Mermaid Adventures");
            InputManager.InitInputManager();
            StateMachine.AddState(new MainMenuState());

            while(DisplayManager.Window.IsOpen){
                StateMachine.ProcessStateChanges();
                Delta.UpdateDelta();

                DisplayManager.Window.DispatchEvents();

                if(InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.LAlt)&&InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.F4)){
                    DisplayManager.Window.Close();
                }

                if (!StateMachine.IsEmpty)
                {
                    StateMachine.ActiveState.Update();
                    StateMachine.ActiveState.HandleInput();
                }

                DisplayManager.Window.Clear();
                if (!StateMachine.IsEmpty)
                    RenderSystem.Render(StateMachine.ActiveState);
                DisplayManager.Window.Display();
            }

            StateMachine.CleanUp();
            AudioSystem.CleanUp();
        }
    }
}
