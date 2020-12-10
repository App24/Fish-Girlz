using System;
using Fish_Girlz.Utils;
using Fish_Girlz.Dialog;

namespace Fish_Girlz.Entities.Components{
    public class DialogComponent : EntityComponent
    {
        private int distance;

        public DialogComponent(int distance){
            this.distance=distance;
        }

        public override void Init()
        {

        }

        public override void Update(params object[] args)
        {
            PlayerEntity player=(PlayerEntity)args[0];
            DialogBox dialogBox=(DialogBox)args[1];
            if(player!=null&&dialogBox!=null){
                if(ParentEntity.Position.Distance(player.Position)<=distance){
                    
                }
            }
        }
    }
}