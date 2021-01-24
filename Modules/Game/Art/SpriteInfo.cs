using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Art{
    public class SpriteInfo{
        public Texture Texture{get;}
        public IntRect Bounds{get;}
        public Vector2i TextureOffset{get{return new Vector2i(Bounds.Left, Bounds.Top);}}
        public int Layer{get;set;}

        public SpriteInfo(Texture texture, IntRect bounds){
            this.Texture=texture;
            this.Bounds=bounds;
        }

        public static explicit operator LayeredSprite(SpriteInfo spriteInfo){
            LayeredSprite sprite=new LayeredSprite(spriteInfo.Texture);
            sprite.TextureRect=spriteInfo.Bounds;
            sprite.Layer=spriteInfo.Layer;
            return sprite;
        }
    }
}