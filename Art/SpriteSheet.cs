using System;
using SFML.Graphics;

namespace Fish_Girlz.Art{
    public class SpriteSheet {
        private Texture texture;
        private int width, height;

        public SpriteSheet(Texture texture, int spriteWidth, int spriteHeight){
            this.texture=texture;
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
            SpriteInfo spriteInfo=new SpriteInfo(texture, bounds);
            return spriteInfo;
        }

        public LayeredSprite GetSprite(IntRect bounds){
            LayeredSprite sprite=new LayeredSprite(texture);
            sprite.TextureRect=bounds;
            return sprite;
        }

        public IntRect GetTextureRect(int x, int y){
            return new IntRect(x*width, y*height, width, height);
        }

        public int SpriteWidth=>width;

        public int SpriteHeight=>height;

        public Texture Texture=>texture;
    }
}