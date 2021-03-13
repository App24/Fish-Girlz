using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Art{
    public class Spritesheet {
        public Texture Texture {get;}
        public uint SpriteWidth{get;}
        public uint SpriteHeight{get;}

        public Spritesheet(Texture texture, uint spriteWidth, uint spriteHeight){
            Texture=texture;
            SpriteWidth=spriteWidth;
            SpriteHeight=spriteHeight;
        }

        public Texture GetTexture(uint x, uint y){
            if(x<0||y<0||x>=Texture.Size.X/SpriteWidth||y>=Texture.Size.Y/SpriteHeight) return null;
            Texture texture=new Texture(Texture.CopyToImage(), new IntRect((int)(x*SpriteWidth), (int)(y* SpriteHeight), (int)SpriteWidth, (int)SpriteHeight));
            return texture;
        }
    }
}