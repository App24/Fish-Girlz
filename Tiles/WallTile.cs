using Fish_Girlz.Systems;
using SFML.Graphics;

namespace Fish_Girlz.Tiles{
    public class WallTile : Tile
    {
        public WallTile() : base(AssetManager.GetTexture("Wall"))
        {
            Collidable=true;
        }
    }
}