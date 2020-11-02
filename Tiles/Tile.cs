using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.Tiles{
    public abstract class Tile {
        public SpriteInfo Sprite {get; protected set;}

        public Vector2f Position{get;set;}

        public CollisionEventHandler OnCollision;

        public LayeredSprite ToLayeredSprite(){
            LayeredSprite sprite=new LayeredSprite(Sprite.texture);
            sprite.TextureRect=Sprite.bounds;
            sprite.Position=Position;
            return sprite;
        }
    }
}