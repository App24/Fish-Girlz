using SFML.Graphics;

namespace Fish_Girlz.Misc{
    public struct FontInfo {
        public Font Font{get;}
        public uint CharacterSize{get;}

        public FontInfo(Font font, uint characterSize){
            Font=font;
            CharacterSize=characterSize;
        }
    }
}