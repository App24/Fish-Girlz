using System;
using System.Collections.Generic;
using Fish_Girlz.States;

namespace Fish_Girlz.Systems{
    public static class StateMachine {
        static bool isAdd, isRemove, isReplace;

        static Stack<State> states=new Stack<State>();

        public static bool IsEmpty=>states.Count<=0;

        public static State ActiveState{get{if(IsEmpty) return null; return states.Peek();}}

        static State newState;

        public static T AddState<T>(T state, bool replace=true) where T : State{
            isReplace=replace;
            isAdd=true;
            newState=state;
            return state;
        }

        public static void RemoveState(){
            isRemove=true;
        }

        public static void ProcessStateChanges(){
            if(isRemove&&!IsEmpty){
                ActiveState.Remove();
                
                Logger.Log($"Removed State {ActiveState}", Logger.LogLevel.Debug);
                states.Pop();

                if (!IsEmpty){
                    Logger.Log($"Resumed State {ActiveState}", Logger.LogLevel.Debug);
                    ActiveState.Resume();
                }
                isRemove = false;
            }

            if (isAdd)
            {
                if (!IsEmpty)
                {
                    if (isReplace){
                        Logger.Log($"Removed State {ActiveState}", Logger.LogLevel.Debug);
                        states.Pop();
                    }
                    else{
                        Logger.Log($"Paused State {ActiveState}", Logger.LogLevel.Debug);
                        ActiveState.Pause();
                    }
                }

                Logger.Log($"Switching To State {newState}", Logger.LogLevel.Debug);
                states.Push(newState);
                ActiveState.Init();
                isAdd = false;
            }
        }

        public static void DisposeStateMachine(){
            while(!IsEmpty) {
                isRemove=true;
                ProcessStateChanges();
            }
            Logger.Log("StateMachine Disposed!");
        }
    }
}