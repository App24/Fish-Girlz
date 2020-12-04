using System;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using Fish_Girlz.Audio;
using DiscordRPC;
using DiscordRPC.Events;
using DiscordRPC.Message;
using DiscordRPC.Logging;

namespace Fish_Girlz
{
    public class Program
    {
        public static string Version="Alpha 1.0.0";

        public static DiscordRpcClient client { get; private set; }
        private static ulong startTime { get; set;}
        public static RichPresence RichPresence;

        public static void Main(string[] args)
        {
            AssetLoader.LoadAssets();
            DisplayManager.CreateWindow(1280,720, "Fish Girlz: Mermaid Adventures");
            InputManager.InitInputManager();
            StateMachine.AddState(new MainMenuState());
            client = new DiscordRpcClient("772930748784967750");
            client.Logger = new ConsoleLogger() { Level = LogLevel.Error };
            client.Initialize();

            startTime = (ulong)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            RichPresence = new RichPresence()
            {
                Details = Version,
                Assets = new Assets()
                {
                    LargeImageKey = "image"
                },
                Timestamps = new Timestamps()
                {
                    StartUnixMilliseconds = startTime
                }
            };

            client.SetPresence(RichPresence);

            while(DisplayManager.Window.IsOpen){
                StateMachine.ProcessStateChanges();
                Delta.UpdateDelta();

                DisplayManager.Window.DispatchEvents();

                if(InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.LAlt)&&InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.F4)){
                    DisplayManager.Window.Close();
                }

                if (!StateMachine.IsEmpty)
                {
                    LogicSystem.Update();
                    CollisionSystem.CheckCollisions();
                    
                    StateMachine.ActiveState.Update();
                    StateMachine.ActiveState.HandleInput();
                }

                DisplayManager.Window.Clear();
                if (!StateMachine.IsEmpty)
                    RenderSystem.Render();
                DisplayManager.Window.Display();

                InputManager.ResetInputManager();
            }

            StateMachine.CleanUp();
            AudioSystem.CleanUp();
            client.Deinitialize();
            client.Dispose();
        }
    }
}
