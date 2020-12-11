using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.States;
using Fish_Girlz.Misc;
using Fish_Girlz.Dialog;
using Fish_Girlz.Entities.Components;
using SFML.System;

namespace Fish_Girlz.Entities{
    public class TestNPC : NPCEntity
    {
        public TestNPC(Vector2f position, SpriteInfo sprite, int maxHealth) : base(position, sprite, maxHealth)
        {
            List<DialogInfo> dialogs=new List<DialogInfo>();
            dialogs.Add(new DialogInfo(CharacterInfo.DOMINIQUE, "dialog.test1", true));
            dialogs.Add(new DialogInfo(CharacterInfo.ASTRA, "dialog.test2", true));
            dialogs.Add(new DialogInfo(CharacterInfo.LAURELY, "dialog.test3", true));
            AddComponent(new DialogComponent(dialogs));
            AddComponent(new CollisionComponent());
        }

        public override void Move()
        {

        }

        public override void Update(State currentState)
        {

        }

        protected override void OnDeath()
        {
            
        }
    }
}