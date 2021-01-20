using System;
using Fish_Girlz.Items;

namespace Fish_Girlz.API{
    public class ItemLoader : Loader {

        public ItemLoader(string id) : base(id)
        {
        }

        public void AddItem<T>(T item) where T : Item{
            Item.AddItem(item, ID);
        }
    }
}