using Fish_Girlz.Systems;
using SFML.Graphics;

namespace Fish_Girlz.Tiles{
    public class WaterTile : Tile
    {
        public WaterTile() : base(AssetManager.GetTexture("Water"))
        {
            Collidable=true;
        }
    }
}