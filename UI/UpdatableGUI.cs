using SFML.System;

namespace Fish_Girlz.UI{
    public abstract class UpdatableGUI : GUI
    {
        public UpdatableGUI(Vector2f position) : base(position)
        {
        }

        public abstract void Update();
    }
}