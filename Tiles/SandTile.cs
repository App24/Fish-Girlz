using Fish_Girlz.Systems;
using SFML.Graphics;

namespace Fish_Girlz.Tiles{
    public class SandTile : Tile
    {
        public SandTile() : base(AssetManager.GetTexture("Sand"))
        {
        }
    }
}