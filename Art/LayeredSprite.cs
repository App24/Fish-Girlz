using System;
using SFML.Graphics;

namespace Fish_Girlz.Art{
    public class LayeredSprite : Sprite {
        public int Layer {get;set;}

        public LayeredSprite(){}
        public LayeredSprite(LayeredSprite copy):base(copy){this.Layer=copy.Layer;}
        public LayeredSprite(Texture texture):base(texture){}
        public LayeredSprite(Texture texture, IntRect rectangle):base(texture, rectangle){}

        public int CompareTo(LayeredSprite layeredSprite){
            if(layeredSprite==null)
                return 1;
            else
                return Layer.CompareTo(layeredSprite.Layer);
        }

        public static explicit operator SpriteInfo(LayeredSprite sprite){
            SpriteInfo spriteInfo=new SpriteInfo(sprite.Texture, sprite.TextureRect);
            spriteInfo.Layer=sprite.Layer;
            return spriteInfo;
        }
    }
}