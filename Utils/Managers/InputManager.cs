using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace Fish_Girlz.Utils
{
    public static class InputManager
    {
        private static bool[] keysPressed = new bool[(int)Keyboard.Key.KeyCount];
        private static bool[] mouseButtonPressed=new bool[(int)Mouse.Button.ButtonCount];

        public static Vector2f MousePosition{get; private set;}

        public static void InitInputManager(){
            DisplayManager.Window.MouseMoved+=MouseMoved;
        }

        public static bool IsKeyHeld(Keyboard.Key key)
        {
            return Keyboard.IsKeyPressed(key);
        }

        public static bool IsKeyPressed(Keyboard.Key key)
        {
            if (Keyboard.IsKeyPressed(key) && !keysPressed[(int)key])
            {
                keysPressed[(int)key] = true;
                return true;
            }else if (!Keyboard.IsKeyPressed(key))
            {
                keysPressed[(int)key] = false;
            }
            return false;
        }

        public static bool IsMouseButtonHeld(Mouse.Button button)
        {
            return Mouse.IsButtonPressed(button);
        }

        public static bool IsMouseButtonPressed(Mouse.Button button)
        {
            if (Mouse.IsButtonPressed(button) && !mouseButtonPressed[(int)button])
            {
                mouseButtonPressed[(int)button] = true;
                return true;
            }
            else if (!Mouse.IsButtonPressed(button))
            {
                mouseButtonPressed[(int)button] = false;
            }
            return false;
        }

        private static void MouseMoved(object sender, MouseMoveEventArgs e){
            MousePosition=new Vector2f(e.X,e.Y);
        }

        public static bool Hover(Vector4f bounds){
            return MousePosition.X>=bounds.X&&MousePosition.Y>=bounds.Y&&MousePosition.X<=bounds.X+bounds.Z&&MousePosition.Y<=bounds.Y+bounds.W;
        }
    }
}
