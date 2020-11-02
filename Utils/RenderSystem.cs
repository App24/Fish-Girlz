using System;
using Fish_Girlz.Art;
using Fish_Girlz.UI;
using Fish_Girlz.States;
using Fish_Girlz.Entities;
using Fish_Girlz.UI.Components;
using SFML.Graphics;
using System.Collections.Generic;
using SFML.System;

namespace Fish_Girlz.Utils{
    public static class RenderSystem {
        public static void Render(State currentState){
            RenderSprites(currentState.GetSprites());
            RenderEntities(currentState.GetEntities());
            RenderGUI(currentState.GetGUIs());
        }

        private static void RenderSprites(List<LayeredSprite> sprites){
            sprites.Sort();

            foreach (LayeredSprite sprite in sprites)
            {
                DisplayManager.Window.Draw(sprite);
            }
        }

        private static void RenderEntities(List<Entity> entities){
            entities.Sort();

            foreach(Entity entity in entities){
                LayeredSprite sprite=(LayeredSprite)entity.Sprite;
                sprite.Position=entity.Position;
                DisplayManager.Window.Draw(sprite);
            }
        }

        private static void RenderGUI(List<GUI> guis){
            View view=new View(DisplayManager.Window.GetView());
            DisplayManager.Window.SetView(DisplayManager.Window.DefaultView);
            foreach(GUI gui in guis){
                List<GUIComponent> guiComponents=gui.GetGUIComponents();
                guiComponents.Sort();
                foreach(GUIComponent guiComponent in guiComponents){
                    if(guiComponent is ImageComponent){
                        ImageComponent imageComponent=(ImageComponent)guiComponent;
                        Sprite sprite=new Sprite(imageComponent.Texture);
                        sprite.Position=gui.Position;
                        DisplayManager.Window.Draw(sprite);
                    }else if(guiComponent is TextComponent){
                        TextComponent textComponent=(TextComponent) guiComponent;
                        Text text=new Text(textComponent.Text, textComponent.Font);
                        text.Position=gui.Position+textComponent.Position;
                        text.FillColor=textComponent.TextColor;
                        DisplayManager.Window.Draw(text);
                    }
                }
            }
            DisplayManager.Window.SetView(view);
        }
    }
}