using System;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using SFML.System;

namespace Fish_Girlz.Entities.Tiles{
    public class WallTileEntity : TileEntity
    {
        public WallTileEntity(Vector2f position) : base(position, (SpriteInfo)new LayeredSprite(AssetManager.GetTexture("temp")), true, 1)
        {

        }

        public override void Update()
        {

        }
    }
}