using System;
using Fish_Girlz.Systems;
using Fish_Girlz.Utils;

namespace Fish_Girlz
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.InitLogger();

            DisplayManager.InitialiseDisplay(1280, 720, "Fish Girlz: Mermaid Adventures");

            InputManager.InitialiseInputManager();

            Assets.Load();

            StateMachine.AddState(new States.MainMenuState());

            while(DisplayManager.Window.IsOpen){
                StateMachine.ProcessStateChanges();
                Delta.UpdateDelta();

                DisplayManager.Window.DispatchEvents();

                if(!StateMachine.IsEmpty){
                    StateMachine.ActiveState.StateLogic();
                    StateMachine.ActiveState.Update();
                    StateMachine.ActiveState.HandleInput();

                    LogicSystem.Update();
                }

                DisplayManager.Window.Clear();
                if(!StateMachine.IsEmpty)
                    RenderSystem.Render();
                DisplayManager.Window.Display();
                InputManager.ResetInputManager();
            }

            DisplayManager.DisposeDisplay();
        }
    }
}
