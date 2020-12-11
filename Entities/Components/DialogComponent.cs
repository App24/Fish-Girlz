using System;
using System.Collections.Generic;
using Fish_Girlz.Utils;
using Fish_Girlz.Dialog;

namespace Fish_Girlz.Entities.Components{
    public class DialogComponent : EntityComponent
    {
        public List<DialogInfo> Dialogs{get;}

        public DialogComponent(List<DialogInfo> dialogs){
            this.Dialogs=dialogs;
        }

        public override void Init()
        {

        }
    }
}