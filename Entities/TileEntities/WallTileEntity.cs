using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using SFML.System;

namespace Fish_Girlz.Entities.Tiles{
    public class WallTileEntity : TileEntity
    {
        public WallTileEntity(Vector2f position) : base(position, (SpriteInfo)new LayeredSprite(AssetManager.GetTexture("temp")), true, 1)
        {

        }

        public override void Move()
        {
            
        }

        public override void Update(State currentState)
        {

        }
    }
}