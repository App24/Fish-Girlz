using System;
using Fish_Girlz.Art;
using Fish_Girlz.UI;
using Fish_Girlz.Inventory.UI;
using Fish_Girlz.States;
using Fish_Girlz.Entities;
using Fish_Girlz.Entities.Tiles;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.UI.Components;
using SFML.Graphics;
using System.Collections.Generic;
using SFML.System;
using Fish_Girlz.Entities.Items;
using Fish_Girlz.Utils;
using Fish_Girlz.Localisation;

namespace Fish_Girlz.Systems{
    public static class RenderSystem {
        public static void Render(){
            State currentState=StateMachine.ActiveState;
            RenderTiles(currentState.GetTileEntities());
            RenderItems(currentState.GetItems());
            RenderEntities(currentState.GetEntities());
            RenderSprites(currentState.GetSprites());
            RenderGUI(currentState.GetGUIs());
        }

        static void RenderItems(List<ItemEntity> itemEntities){
            itemEntities.Sort();

            foreach (ItemEntity item in itemEntities)
            {
                LayeredSprite sprite=(LayeredSprite)item.Sprite;
                sprite.Position=item.Position;
                sprite.Rotation=item.Rotation;
                //CollisionComponent collision=item.GetComponent<CollisionComponent>();
                //if(collision!=null){
                //    Sprite collisionSprite=new Sprite(Utilities.CreateTexture((uint)(collision.CollisionBounds.Width-collision.CollisionBounds.Left), (uint)(collision.CollisionBounds.Height-collision.CollisionBounds.Top), Color.Blue));
                //    collisionSprite.Position=item.Position+new Vector2f(collision.CollisionBounds.Left, collision.CollisionBounds.Top);
                //    DisplayManager.Window.Draw(collisionSprite);
                //}
                DisplayManager.Window.Draw(sprite);
            }
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
                //CollisionComponent collision=entity.GetComponent<CollisionComponent>();
                //if(collision!=null){
                //    Sprite collisionSprite=new Sprite(Utilities.CreateTexture((uint)(collision.CollisionBounds.Width-collision.CollisionBounds.Left), (uint)(collision.CollisionBounds.Height-collision.CollisionBounds.Top), Color.Blue));
                //    collisionSprite.Position=entity.Position+new Vector2f(collision.CollisionBounds.Left, collision.CollisionBounds.Top);
                //    DisplayManager.Window.Draw(collisionSprite);
                //}
                DisplayManager.Window.Draw(sprite);
            }
        }

        private static void RenderGUI(List<GUI> guis){
            View view=new View(DisplayManager.Window.GetView());
            DisplayManager.Window.SetView(DisplayManager.Window.DefaultView);
            guis.Sort();
            foreach(GUI gui in guis){
                if(!gui.Visible) continue;
                List<GUIComponent> guiComponents=gui.GetGUIComponents();
                foreach(GUIComponent guiComponent in guiComponents){
                    if(!guiComponent.Visible) continue;
                    if(guiComponent is TextureComponent){
                        TextureComponent textureComponent=(TextureComponent)guiComponent;
                        if(textureComponent.Texture==null) continue;
                        Sprite sprite=new Sprite(textureComponent.Texture);
                        sprite.Position=gui.Position+textureComponent.Position;
                        sprite.Rotation=textureComponent.Rotation;
                        Vector2f temp=new Vector2f(1,1);
                        if(textureComponent.MaxSize!=new Vector2u()){
                            temp=new Vector2f(textureComponent.MaxSize.X/(float)textureComponent.Texture.Size.X, textureComponent.MaxSize.Y/(float)textureComponent.Texture.Size.Y);
                        }
                        sprite.Scale=new Vector2f(textureComponent.Scale.X*temp.X, textureComponent.Scale.Y*temp.Y);
                        DisplayManager.Window.Draw(sprite);
                    }else if(guiComponent is TextComponent){
                        TextComponent textComponent=(TextComponent) guiComponent;
                        if(string.IsNullOrEmpty(textComponent.Text)) continue;
                        FontInfo fontInfo=textComponent.FontInfo;
                        Text text=new Text(Language.GetDefault().GetTranslation(textComponent.Text), fontInfo.Font, fontInfo.Size);
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
                    }else if(guiComponent is UISlot){
                        UISlot slotComponent=(UISlot)guiComponent;
                        Sprite slotSprite=new Sprite(slotComponent.SlotTexture);
                        slotSprite.Position=gui.Position+slotComponent.Position;
                        Vector2f temp=new Vector2f(1,1);
                        Sprite itemSprite=new Sprite(Utilities.CreateTexture(1,1,new Color(0,0,0,0)));
                        if(slotComponent.Slot!=null&&slotComponent.Slot.Item!=null){
                            itemSprite=new Sprite(slotComponent.Slot.Item.Sprite.Texture);
                        }
                        itemSprite.Position=slotSprite.Position;
                        if(slotComponent.Slot!=null&&slotComponent.Slot.Item!=null&&(slotComponent.Slot.Item.Sprite.Texture.Size!=slotComponent.SlotTexture.Size)){
                            //temp=new Vector2f(slotComponent.MaxSize.X/(float)slotComponent.Texture.Size.X, slotComponent.MaxSize.Y/(float)slotComponent.Texture.Size.Y);
                            temp=new Vector2f(slotComponent.SlotTexture.Size.X/(float)slotComponent.Slot.Item.Sprite.Texture.Size.X, slotComponent.SlotTexture.Size.Y/(float)slotComponent.Slot.Item.Sprite.Texture.Size.Y);
                        }
                        slotSprite.Scale=new Vector2f(1*temp.X, 1*temp.Y);
                        DisplayManager.Window.Draw(slotSprite);
                        DisplayManager.Window.Draw(itemSprite);
                        if(slotComponent.Slot!=null&&slotComponent.Slot.Item!=null){
                            FontInfo fontInfo=slotComponent.FontInfo;
                            if(slotComponent.Slot.Amount>0&&slotComponent.Slot.Item.MaxStack>1)
                            DrawText(slotComponent.Slot.Amount.ToString(), fontInfo, gui.Position+slotComponent.Position, view);
                        }
                    }
                }
            }
            foreach(GUI gui in guis){
                if(!gui.Visible) continue;
                List<GUIComponent> guiComponents=gui.GetGUIComponents();
                foreach(GUIComponent guiComponent in guiComponents){
                    if(guiComponent is UISlot){
                        UISlot slotComponent=(UISlot)guiComponent;
                        if(slotComponent.Slot==null||slotComponent.Slot.Item==null)continue;
                        FontInfo fontInfo=slotComponent.FontInfo;
                        if(slotComponent.ShowItemName)
                        DrawText(Language.GetDefault().GetTranslation(slotComponent.Slot.Item.Name), fontInfo, InputManager.MousePosition+new Vector2f(0,-fontInfo.Size), view);
                    }
                }
            }
            DisplayManager.Window.SetView(view);
        }

        static void DrawText(string textString, FontInfo fontInfo, Vector2f position, View view){
            Text text=new Text(textString, fontInfo.Font, fontInfo.Size);
            text.Position=position;
            text.FillColor=Color.Black;
            text.OutlineColor=Color.White;
            text.OutlineThickness=1;
            float textWidth=text.GetLocalBounds().Width+10;
            float textHeight=text.CharacterSize+10;
            float x=text.Position.X;
            float y=text.Position.Y;
            text.Position=new Vector2f();
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