using Fish_Girlz.States;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Fish_Girlz.Systems{
    internal static class StateMachine {
        private static bool isAdding, isReplacing, isRemoving;
        private static Stack<State> states=new Stack<State>();
        private static State newState;

        public static T AddState<T>(T newState, bool replace=true) where T : State{
            isReplacing=replace;
            isAdding=true;
            StateMachine.newState=newState;
            return newState;
        }

        public static void RemoveState(){
            isRemoving=true;
        }

        public static bool IsEmpty=>states.Count<=0;

        public static State ActiveState => states.Peek();

        public static void ProcessStateChanges()
        {
            if (isRemoving && !IsEmpty)
            {
                ActiveState.Remove();
                
                Logger.Log($"Removed State {ActiveState}", Logger.LogLevel.Debug);
                states.Pop();

                if (!IsEmpty){
                    Logger.Log($"Resumed State {ActiveState}", Logger.LogLevel.Debug);
                    ActiveState.Resume();
                }
                isRemoving = false;
            }

            if (isAdding)
            {
                if (!IsEmpty)
                {
                    if (isReplacing){
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
                isAdding = false;
            }
        }

        public static void CleanUp() {
            while(!IsEmpty) {
                isRemoving=true;
                ProcessStateChanges();
            }
            Logger.Log("Cleaned All States!");
        }
    }
}