

using SFML.System;
using SFML.Window;

namespace Fish_Girlz.Systems{
    public static class InputManager {
        static bool initialised=false;

        private static bool[] keysHeld = new bool[(int)Keyboard.Key.KeyCount];
        private static bool[] keysPressed = new bool[(int)Keyboard.Key.KeyCount];
        private static bool[] keysPressedThisFrame = new bool[(int)Keyboard.Key.KeyCount];
        private static bool typing=false;

        private static bool[] mouseButtonsHeld=new bool[(int)Mouse.Button.ButtonCount];
        private static bool[] mouseButtonsPressed=new bool[(int)Mouse.Button.ButtonCount];
        private static bool[] mouseButtonsPressedThisFrame=new bool[(int)Mouse.Button.ButtonCount];
        private static bool[] clickedUI=new bool[(int)Mouse.Button.ButtonCount];

        public static Vector2f MousePosition{get; private set;}

        public static float ScrollDelta{get;private set;}
        private static bool altHeld, shiftHeld, ctrlHeld;

        public static void InitialiseInputManager(){
            if(initialised) return;
            DisplayManager.Window.MouseMoved+=MouseMoved;
            DisplayManager.Window.KeyPressed+=KeyPressed;
            DisplayManager.Window.KeyReleased+=KeyReleased;
            DisplayManager.Window.MouseButtonPressed+=MouseButtonPressed;
            DisplayManager.Window.MouseButtonReleased+=MouseButtonReleased;
            DisplayManager.Window.MouseWheelScrolled+=MouseWheelScrolled;
            Logger.Log("Input Manager Initialised!");
            initialised=true;
        }

        public static void ResetInputManager(){
            for (int i = 0; i < mouseButtonsPressedThisFrame.Length; i++)
            {
                mouseButtonsPressedThisFrame[i]=false;
            }
            for (int i = 0; i < keysPressedThisFrame.Length; i++)
            {
                keysPressedThisFrame[i]=false;
            }
            ScrollDelta=0;
        }

        #region Key
        public static bool IsKeyHeld(Keyboard.Key key)
        {
            if(typing) return false;
            return keysHeld[(int)key];
        }

        public static bool IsKeyPressed(Keyboard.Key key)
        {
            if(typing) return false;
            if(keysPressedThisFrame[(int)key])
                return true;
            if (keysHeld[(int)key] && !keysPressed[(int)key])
            {
                keysPressed[(int)key] = true;
                keysPressedThisFrame[(int)key]=true;
                return true;
            }else if (!keysHeld[(int)key])
            {
                keysPressed[(int)key] = false;
            }
            return false;
        }

        internal static void SetTyping(bool value){
            typing=value;
        }

        public static bool IsAltHeld(){
            return altHeld;
        }

        public static bool IsControlHeld(){
            return ctrlHeld;
        }

        public static bool IsShiftHeld(){
            return shiftHeld;
        }

        public static bool IsDownPressed(){
            return IsKeyPressed(Keyboard.Key.Down)||IsKeyPressed(Keyboard.Key.S);
        }

        public static bool IsUpPressed(){
            return IsKeyPressed(Keyboard.Key.Up)||IsKeyPressed(Keyboard.Key.W);
        }

        public static bool IsLeftPressed(){
            return IsKeyPressed(Keyboard.Key.Left)||IsKeyPressed(Keyboard.Key.A);
        }

        public static bool IsRightPressed(){
            return IsKeyPressed(Keyboard.Key.Right)||IsKeyPressed(Keyboard.Key.D);
        }

        public static bool IsDownHeld(){
            return IsKeyHeld(Keyboard.Key.Down)||IsKeyHeld(Keyboard.Key.S);
        }

        public static bool IsUpHeld(){
            return IsKeyHeld(Keyboard.Key.Up)||IsKeyHeld(Keyboard.Key.W);
        }

        public static bool IsLeftHeld(){
            return IsKeyHeld(Keyboard.Key.Left)||IsKeyHeld(Keyboard.Key.A);
        }

        public static bool IsRightHeld(){
            return IsKeyHeld(Keyboard.Key.Right)||IsKeyHeld(Keyboard.Key.D);
        }

        public static bool IsSelectPressed(){
            return IsKeyPressed(Keyboard.Key.Enter)||IsKeyPressed(Keyboard.Key.Space);
        }

        public static bool IsEscPressed(){
            return IsKeyPressed(Keyboard.Key.Escape);
        }
        #endregion

        #region Mouse
        public static bool IsMouseButtonHeld(Mouse.Button button)
        {
            if(clickedUI[(int)button]) return false;
            return mouseButtonsHeld[(int) button];
        }

        public static bool IsMouseButtonPressedNoUI(Mouse.Button button){
            if(mouseButtonsPressedThisFrame[(int)button]){
                return true;
            }
            if (mouseButtonsHeld[(int) button] && !mouseButtonsPressed[(int)button])
            {
                mouseButtonsPressed[(int)button] = true;
                mouseButtonsPressedThisFrame[(int)button]=true;
                return true;
            }
            else if (!mouseButtonsHeld[(int) button])
            {
                mouseButtonsPressed[(int)button] = false;
            }
            return false;
        }

        public static bool IsMouseButtonPressed(Mouse.Button button)
        {
            if(clickedUI[(int)button]) return false;
            return IsMouseButtonPressedNoUI(button);
        }
        #endregion

        public static void ClickedUI(Mouse.Button button){
            clickedUI[(int)button]=true;
        }

        #region Events

        private static void MouseWheelScrolled(object sender, MouseWheelScrollEventArgs e){
            ScrollDelta=e.Delta;
        }

        private static void MouseButtonPressed(object sender, MouseButtonEventArgs e){
            mouseButtonsHeld[(int)e.Button]=true;
        }

        private static void MouseButtonReleased(object sender, MouseButtonEventArgs e){
            mouseButtonsHeld[(int)e.Button]=false;
            clickedUI[(int)e.Button]=false;
        }

        private static void MouseMoved(object sender, MouseMoveEventArgs e){
            MousePosition=new Vector2f(e.X,e.Y);
        }

        private static void KeyPressed(object sender, KeyEventArgs e){
            if((int)e.Code<0||(int)e.Code>(int)Keyboard.Key.KeyCount)
                return;
            keysHeld[(int)e.Code]=true;
            altHeld=e.Alt;
            ctrlHeld=e.Control;
            shiftHeld=e.Shift;
        }

        private static void KeyReleased(object sender, KeyEventArgs e){
            if((int)e.Code<0||(int)e.Code>(int)Keyboard.Key.KeyCount)
                return;
            keysHeld[(int)e.Code]=false;
            altHeld=e.Alt;
            ctrlHeld=e.Control;
            shiftHeld=e.Shift;
        }
        #endregion
    }
}