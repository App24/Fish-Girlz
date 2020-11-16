using System;
using SFML.Graphics;
using SFML.System;
using Fish_Girlz.Entities;

namespace Fish_Girlz.Utils{
    public static class Camera {
        public static void Move(Vector2f offset){
            View view=DisplayManager.GetView();
            view.Move(offset);
            DisplayManager.Window.SetView(view);
        }
        public static void Move(float x, float y){
            Move(new Vector2f(x,y));
        }

        public static void TargetEntity(Entity entity){
            Vector2i WorldToScreen = DisplayManager.Window.MapCoordsToPixel(entity.Position);
            if (WorldToScreen.X > float.MinValue && WorldToScreen.X < DisplayManager.Width / 5f)
            {
                Camera.Move((WorldToScreen.X - (DisplayManager.Width / 5f)) * Delta.GetDelta() * 2f, 0);
            }
            else
            if (WorldToScreen.X < float.MaxValue && WorldToScreen.X > DisplayManager.Width - DisplayManager.Width / 5f)
            {
                Camera.Move((WorldToScreen.X - (DisplayManager.Width - DisplayManager.Width / 5f)) * Delta.GetDelta() * 2f, 0);
            }

            if (WorldToScreen.Y > float.MinValue && WorldToScreen.Y < DisplayManager.Height / 4f)
            {
                Camera.Move(0, (WorldToScreen.Y - (DisplayManager.Height / 4f)) * Delta.GetDelta() * 2f);
            }
            else
            if (WorldToScreen.Y < float.MaxValue && WorldToScreen.Y > DisplayManager.Height - DisplayManager.Height / 4f)
            {
                Camera.Move(0, (WorldToScreen.Y - (DisplayManager.Height - DisplayManager.Height / 4f)) * Delta.GetDelta() * 2f);
            }
        }
    }
}