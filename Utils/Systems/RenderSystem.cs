using System;
using Fish_Girlz.Art;
using Fish_Girlz.UI;
using Fish_Girlz.States;
using Fish_Girlz.Entities;
using Fish_Girlz.Entities.Tiles;
using Fish_Girlz.UI.Components;
using SFML.Graphics;
using System.Collections.Generic;
using SFML.System;

namespace Fish_Girlz.Utils{
    public static class RenderSystem {
        public static void Render(){
            State currentState=StateMachine.ActiveState;
            RenderTiles(currentState.GetTiles());
            RenderSprites(currentState.GetSprites());
            RenderEntities(currentState.GetEntities());
            RenderGUI(currentState.GetGUIs());
        }

        private static void RenderTiles(List<TileEntity> tileEntities){
            tileEntities.Sort();

            foreach(TileEntity tileEntity in tileEntities){
                LayeredSprite sprite=(LayeredSprite)tileEntity.Sprite;
                sprite.Position=tileEntity.Position;
                DisplayManager.Window.Draw(sprite);
            }
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
                sprite.Rotation=entity.Rotation;
                //Sprite collisionSprite=new Sprite(Utilities.CreateTexture((uint)(entity.CollisionBounds.Width-entity.CollisionBounds.Left), (uint)(entity.CollisionBounds.Height-entity.CollisionBounds.Top), Color.Blue));
                //collisionSprite.Position=entity.Position+new Vector2f(entity.CollisionBounds.Left, entity.CollisionBounds.Top);
                //sprite.Rotation=entity.Rotation;
                //DisplayManager.Window.Draw(collisionSprite);
                DisplayManager.Window.Draw(sprite);
            }
        }

        private static void RenderGUI(List<GUI> guis){
            View view=new View(DisplayManager.Window.GetView());
            DisplayManager.Window.SetView(DisplayManager.Window.DefaultView);
            foreach(GUI gui in guis){
                if(!gui.Visible) continue;
                List<GUIComponent> guiComponents=gui.GetGUIComponents();
                foreach(GUIComponent guiComponent in guiComponents){
                    if(guiComponent is TextureComponent){
                        TextureComponent textureComponent=(TextureComponent)guiComponent;
                        Sprite sprite=new Sprite(textureComponent.Texture);
                        sprite.Position=gui.Position+textureComponent.Position;
                        Vector2f temp=new Vector2f(1,1);
                        if(textureComponent.MaxSize!=new Vector2u()){
                            temp=new Vector2f(textureComponent.MaxSize.X/(float)textureComponent.Texture.Size.X, textureComponent.MaxSize.Y/(float)textureComponent.Texture.Size.Y);
                        }
                        sprite.Scale=new Vector2f(textureComponent.Scale.X*temp.X, textureComponent.Scale.Y*temp.Y);
                        DisplayManager.Window.Draw(sprite);
                    }else if(guiComponent is TextComponent){
                        TextComponent textComponent=(TextComponent) guiComponent;
                        FontInfo fontInfo=textComponent.FontInfo;
                        Text text=new Text(textComponent.Text, fontInfo.Font, fontInfo.Size);
                        text.Position=gui.Position+textComponent.Position;
                        text.FillColor=textComponent.TextColor;
                        text.OutlineColor=textComponent.OutlineColor;
                        text.OutlineThickness=textComponent.OutlineThickness;
                        float textWidth=text.GetLocalBounds().Width+10;
                        float textHeight=text.CharacterSize+10;
                        float x=text.Position.X;
                        float y=text.Position.Y;
                        text.Position=new Vector2f();
                        if(gui is UITextField){
                            UITextField uiTextField=(UITextField)gui;
                            textWidth=uiTextField.Size.X;
                            textHeight=uiTextField.Size.Y;
                            x+=1.5f;
                            y+=1.5f;
                            if(uiTextField.CursorIndex>0){
                                float width=uiTextField.CursorPosition;
                                if(width>textWidth){
                                    text.Position=new Vector2f(textWidth-width,0);
                                }
                            }
                        }
                        View textView=new View(new Vector2f(textWidth/2, textHeight/2), new Vector2f(textWidth, textHeight));
                        //Console.WriteLine(textView.Viewport);
                        textView.Viewport=new FloatRect(x/view.Size.X, y/view.Size.Y, (textWidth)/view.Size.X, (textHeight)/view.Size.Y);
                        //Console.WriteLine(textView.Viewport);
                        //textView.Move(text.Position);
                        DisplayManager.Window.SetView(textView);
                        //DisplayManager.Window.Draw(new Sprite(new Texture(500,500).CreateTexture(Color.Blue)));
                        DisplayManager.Window.Draw(text);
                        DisplayManager.Window.SetView(DisplayManager.Window.DefaultView);
                    }
                }
            }
            DisplayManager.Window.SetView(view);
        }
    }
}