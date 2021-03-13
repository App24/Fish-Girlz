using System.Collections.Generic;
using Fish_Girlz.States;
using Fish_Girlz.UI;

namespace Fish_Girlz.Systems{
    public static class LogicSystem {
        public static void Update(){
            State currentState=StateMachine.ActiveState;
            if(currentState==null) return;
            UpdateGUIs(currentState);
        }

        static void UpdateGUIs(State currentState){
            List<GUI> guis=currentState.GetGUIs();
            guis.Reverse();
            List<GUI> removeGuis=new List<GUI>();
            foreach (GUI gui in guis)
            {
                if(gui.Visible)
                if(gui is UpdatableGUI){
                    UpdatableGUI updatableGUI=(UpdatableGUI)gui;
                    updatableGUI.Update();
                }
                if(gui.ToRemove)
                    removeGuis.Add(gui);
            }
            foreach (GUI gui in removeGuis)
            {
                currentState.RemoveGUI(gui);
            }
        }
    }
}