using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Art
{
    public class SpriteSheet {
        public Texture Texture{get;private set;}
        private int width, height;

        public SpriteSheet(Texture texture, int spriteWidth, int spriteHeight){
            this.Texture=texture;
            this.width=spriteWidth;
            this.height=spriteHeight;
        }

        public LayeredSprite GetSprite(int x, int y){
            return GetSprite(GetTextureRect(x,y));
        }

        public SpriteInfo GetSpriteInfo(int x, int y){
            return GetSpriteInfo(GetTextureRect(x,y));
        }

        public SpriteInfo GetSpriteInfo(IntRect bounds){
            SpriteInfo spriteInfo=new SpriteInfo(Texture, bounds);
            return spriteInfo;
        }

        public LayeredSprite GetSprite(IntRect bounds){
            LayeredSprite sprite=new LayeredSprite(Texture);
            sprite.TextureRect=bounds;
            return sprite;
        }

        public IntRect GetTextureRect(int x, int y){
            Vector2i offset=GetTextureOffset(x,y);
            return new IntRect(offset.X, offset.Y, width, height);
        }

        public Vector2i GetTextureOffset(int x, int y){
            return new Vector2i(x*width, y*width);
        }

        public int SpriteWidth=>width;

        public int SpriteHeight=>height;
    }
}