using System;
using System.Collections.Generic;
using Fish_Girlz.States;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Entities;
using Fish_Girlz.Utils;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Systems{
    public static class RenderSystem {
        public static void Render(){
            State currentState=StateMachine.ActiveState;
            if(currentState==null) return;
            RenderEntities(currentState);
            RenderGUIs(currentState);
        }

        static void RenderEntities(State currentState){
            List<Entity> entities=currentState.GetEntities();
            entities.Sort(delegate(Entity entity1, Entity entity2){
                return entity1.Position.Y.CompareTo(entity2.Position.Y);
            });
            foreach (Entity entity in entities)
            {
                Sprite sprite=new Sprite(entity.Texture);
                sprite.Position=entity.Position;
                DisplayManager.Window.Draw(sprite);
            }
        }

        static void RenderGUIs(State currentState){
            View view=new View(DisplayManager.View);
            DisplayManager.View=DisplayManager.Window.DefaultView;
            List<GUI> guis=currentState.GetGUIs();
            foreach(GUI gui in guis){
                if(!gui.Visible) continue;
                List<GUIComponent> guiComponents=gui.GetGUIComponents();
                foreach(GUIComponent guiComponent in guiComponents){
                    if(!guiComponent.Visible) continue;
                    if(guiComponent is TextComponent){
                        TextComponent textComponent=(TextComponent)guiComponent;
                        Text text=new Text(textComponent.Text, textComponent.FontInfo.Font, textComponent.FontInfo.CharacterSize);
                        text.Position=textComponent.GetPosition();
                        text.FillColor=textComponent.FillColor;
                        text.OutlineColor=textComponent.OutlineColor;
                        text.OutlineThickness=textComponent.OutlineThickness;
                        text.Style=textComponent.Style;
                        DisplayManager.Window.Draw(text);
                    }
                }
            }
            DisplayManager.View=view;
        }
    }
}