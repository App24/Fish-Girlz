using Fish_Girlz.States;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Fish_Girlz.Utils{
    public static class StateMachine {
        private static bool isAdding, isReplacing, isRemoving;
        private static Stack<State> states=new Stack<State>();
        private static State newState;

        public static void AddState(State newState, bool replace=true){
            isReplacing=replace;
            isAdding=true;
            StateMachine.newState=newState;
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
                
                states.Pop();

                if (!IsEmpty)
                    ActiveState.Resume();
                isRemoving = false;
            }

            if (isAdding)
            {
                if (!IsEmpty)
                {
                    if (isReplacing)
                        states.Pop();
                    else
                        ActiveState.Pause();
                }

                states.Push(newState);
                ActiveState.InitState();
                ActiveState.Init();
                isAdding = false;
            }
        }

        public static void CleanUp() {
            while(!IsEmpty) {
                isRemoving=true;
                ProcessStateChanges();
            }
        }
    }
}