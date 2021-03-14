using Fish_Girlz.Tiles;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Entities{
    public class TileEntity : Entity
    {
        public Tile Tile{get;}

        public TileEntity(Vector2f position, Tile tile) : base(position, tile.Texture)
        {
            Tile=tile;
        }

        public override void Move()
        {
            
        }

        public override void Update()
        {
            
        }
    }
}