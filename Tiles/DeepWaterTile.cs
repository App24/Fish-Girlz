using Fish_Girlz.Systems;
using SFML.Graphics;

namespace Fish_Girlz.Tiles{
    public class DeepWaterTile : Tile
    {
        public DeepWaterTile() : base(AssetManager.GetTexture("Deep Water"))
        {
            Collidable=true;
        }
    }
}