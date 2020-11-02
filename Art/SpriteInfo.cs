using System;
using SFML.Graphics;

namespace Fish_Girlz.Art{
    public class SpriteInfo{
        public Texture texture;
        public IntRect bounds;
        public int Layer;

        public SpriteInfo(Texture texture, IntRect bounds){
            this.texture=texture;
            this.bounds=bounds;
        }

        public static explicit operator LayeredSprite(SpriteInfo spriteInfo){
            LayeredSprite sprite=new LayeredSprite(spriteInfo.texture);
            sprite.TextureRect=spriteInfo.bounds;
            sprite.Layer=spriteInfo.Layer;
            return sprite;
        }
    }
}