using System;
using System.Runtime.InteropServices;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace Fish_Girlz.Utils
{
    public static class InputManager
    {
        private static bool[] keysPressed = new bool[(int)Keyboard.Key.KeyCount];
        private static bool[] mouseButtonsHeld=new bool[(int)Mouse.Button.ButtonCount];
        private static bool[] mouseButtonsPressed=new bool[(int)Mouse.Button.ButtonCount];
        private static bool[] mouseButtonsPressedThisFrame=new bool[(int)Mouse.Button.ButtonCount];

        private static string keyPressed="";

        private static CharacterVisibility characterVisibility;

        public static Vector2f MousePosition{get; private set;}

        public static void InitInputManager(){
            DisplayManager.Window.MouseMoved+=MouseMoved;
            DisplayManager.Window.KeyPressed+=KeyPressed;
            DisplayManager.Window.KeyReleased+=KeyReleased;
            DisplayManager.Window.MouseButtonPressed+=MouseButtonPressed;
            DisplayManager.Window.MouseButtonReleased+=MouseButtonReleased;
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
            return mouseButtonsHeld[(int) button];
        }

        public static bool IsMouseButtonPressed(Mouse.Button button)
        {
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

        public static void ResetInputManager(){
            for (int i = 0; i < mouseButtonsPressedThisFrame.Length; i++)
            {
                mouseButtonsPressedThisFrame[i]=false;
            }
        }

        private static void MouseButtonPressed(object sender, MouseButtonEventArgs e){
            mouseButtonsHeld[(int)e.Button]=true;
        }

        private static void MouseButtonReleased(object sender, MouseButtonEventArgs e){
            mouseButtonsHeld[(int)e.Button]=false;
        }

        private static void MouseMoved(object sender, MouseMoveEventArgs e){
            MousePosition=new Vector2f(e.X,e.Y);
        }

        public static bool Hover(Vector4f bounds){
            return MousePosition.X>=bounds.X&&MousePosition.Y>=bounds.Y&&MousePosition.X<=bounds.X+bounds.Z&&MousePosition.Y<=bounds.Y+bounds.W;
        }

        private static void KeyPressed(object sender, KeyEventArgs e){
            (keyPressed, characterVisibility)=KeyCodeToString(e.Code, e.Shift);
        }

        private static void KeyReleased(object sender, KeyEventArgs e){
            keyPressed="";
        }
        
        public static (string, CharacterVisibility) CheckForInput(){
            string lastKeyPressed=keyPressed;
            keyPressed="";
            return (lastKeyPressed, characterVisibility);
        }

        private static (string, CharacterVisibility) KeyCodeToString(Keyboard.Key key, bool shift){
            string keyText="";
            CharacterVisibility visibility=CharacterVisibility.Visible;
            switch(key){
                case Keyboard.Key.A:
                    keyText="a";
                    break;
                case Keyboard.Key.Add:
                    keyText="+";
                    break;
                case Keyboard.Key.B:
                    keyText="b";
                    break;
                case Keyboard.Key.Backslash:
                    keyText="\\";
                    break;
                case Keyboard.Key.Backspace:
                    keyText="\b";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.C:
                    keyText="c";
                    break;
                case Keyboard.Key.Comma:
                    keyText=",";
                    break;
                case Keyboard.Key.D:
                    keyText="d";
                    break;
                case Keyboard.Key.Delete:
                    keyText="\bd";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.Divide:
                    keyText="/";
                    break;
                case Keyboard.Key.Down:
                    keyText="dArrow";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.E:
                    keyText="e";
                    break;
                case Keyboard.Key.End:
                    keyText="end";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.Enter:
                    keyText="enter";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.Equal:
                    keyText="=";
                    break;
                case Keyboard.Key.Escape:
                    keyText="esc";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F:
                    keyText="f";
                    break;
                case Keyboard.Key.F1:
                    keyText="f1";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F11:
                    keyText="f11";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F12:
                    keyText="f12";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F13:
                    keyText="f13";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F14:
                    keyText="f14";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F15:
                    keyText="f15";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F2:
                    keyText="f2";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F3:
                    keyText="f3";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F4:
                    keyText="f4";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F5:
                    keyText="f5";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F6:
                    keyText="f6";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F7:
                    keyText="f7";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F8:
                    keyText="f8";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.F9:
                    keyText="f9";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.G:
                    keyText="g";
                    break;
                case Keyboard.Key.H:
                    keyText="h";
                    break;
                case Keyboard.Key.Home:
                    keyText="home";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.Hyphen:
                    keyText="-";
                    break;
                case Keyboard.Key.I:
                    keyText="i";
                    break;
                case Keyboard.Key.Insert:
                    keyText="insert";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.J:
                    keyText="j";
                    break;
                case Keyboard.Key.K:
                    keyText="k";
                    break;
                case Keyboard.Key.L:
                    keyText="l";
                    break;
                case Keyboard.Key.LAlt:
                    keyText="lAlt";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.LBracket:
                    keyText="(";
                    break;
                case Keyboard.Key.LControl:
                    keyText="lControl";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.Left:
                    keyText="lArrow";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.LShift:
                    keyText="lShift";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.LSystem:
                    keyText="lSystem";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.M:
                    keyText="m";
                    break;
                case Keyboard.Key.Menu:
                    keyText="menu";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.Multiply:
                    keyText="*";
                    break;
                case Keyboard.Key.N:
                    keyText="n";
                    break;
                case Keyboard.Key.Numpad0:
                case Keyboard.Key.Num0:
                    keyText="0";
                    break;
                case Keyboard.Key.Numpad1:
                case Keyboard.Key.Num1:
                    keyText="1";
                    break;
                case Keyboard.Key.Numpad2:
                case Keyboard.Key.Num2:
                    keyText="2";
                    break;
                case Keyboard.Key.Numpad3:
                case Keyboard.Key.Num3:
                    keyText="3";
                    break;
                case Keyboard.Key.Numpad4:
                case Keyboard.Key.Num4:
                    keyText="4";
                    break;
                case Keyboard.Key.Numpad5:
                case Keyboard.Key.Num5:
                    keyText="5";
                    break;
                case Keyboard.Key.Numpad6:
                case Keyboard.Key.Num6:
                    keyText="6";
                    break;
                case Keyboard.Key.Numpad7:
                case Keyboard.Key.Num7:
                    keyText="7";
                    break;
                case Keyboard.Key.Numpad8:
                case Keyboard.Key.Num8:
                    keyText="8";
                    break;
                case Keyboard.Key.Numpad9:
                case Keyboard.Key.Num9:
                    keyText="9";
                    break;
                case Keyboard.Key.O:
                    keyText="o";
                    break;
                case Keyboard.Key.P:
                    keyText="p";
                    break;
                case Keyboard.Key.PageDown:
                    keyText="pageDown";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.PageUp:
                    keyText="pageUp";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.Pause:
                    keyText="pause";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.Period:
                    keyText=".";
                    break;
                case Keyboard.Key.Q:
                    keyText="q";
                    break;
                case Keyboard.Key.RAlt:
                    keyText="rAlt";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.RBracket:
                    keyText="(";
                    break;
                case Keyboard.Key.RControl:
                    keyText="rControl";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.Right:
                    keyText="rArrow";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.RShift:
                    keyText="rShift";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.RSystem:
                    keyText="rSystem";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.S:
                    keyText="s";
                    break;
                case Keyboard.Key.Semicolon:
                    keyText=";";
                    break;
                case Keyboard.Key.Slash:
                    keyText="/";
                    break;
                case Keyboard.Key.Space:
                    keyText=" ";
                    break;
                case Keyboard.Key.Subtract:
                    keyText="-";
                    break;
                case Keyboard.Key.T:
                    keyText="t";
                    break;
                case Keyboard.Key.Tab:
                    keyText="tab";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.Tilde:
                    keyText="~";
                    break;
                case Keyboard.Key.U:
                    keyText="u";
                    break;
                case Keyboard.Key.Up:
                    keyText="uArrow";
                    visibility=CharacterVisibility.Invisible;
                    break;
                case Keyboard.Key.V:
                    keyText="v";
                    break;
                case Keyboard.Key.W:
                    keyText="w";
                    break;
                case Keyboard.Key.X:
                    keyText="x";
                    break;
                case Keyboard.Key.Y:
                    keyText="y";
                    break;
                case Keyboard.Key.Z:
                    keyText="z";
                    break;
                case Keyboard.Key.Unknown:
                    keyText="�";
                    break;
            }
            if(shift&&visibility==CharacterVisibility.Visible){
                try{
                    char text=char.Parse(keyText);
                    text=GetModifiedKey(text);
                    keyText=text.ToString();
                }catch{

                }
            }
            return (keyText, visibility);
        }

        [DllImport("user32.dll")]
        static extern short VkKeyScan(char c);

        [DllImport("user32.dll", SetLastError=true)]
        static extern int ToAscii(
            uint uVirtKey,
            uint uScanCode,
            byte[] lpKeyState,
            out uint lpChar,
            uint flags
        );

        public static char GetModifiedKey(char c)
        {
            short vkKeyScanResult = VkKeyScan(c);

            // a result of -1 indicates no key translates to input character
            if (vkKeyScanResult == -1)
                throw new ArgumentException("No key mapping for " + c);

            // vkKeyScanResult & 0xff is the base key, without any modifiers
            uint code = (uint)vkKeyScanResult & 0xff;

            // set shift key pressed
            byte[] b = new byte[256];
            b[0x10] = 0x80;

            uint r;
            // return value of 1 expected (1 character copied to r)
            if (1 != ToAscii(code, code, b, out r, 0))
                throw new ApplicationException("Could not translate modified state");

            return (char)r;
        }
    }

    public enum CharacterVisibility{
        Invisible, Visible
    }
}
