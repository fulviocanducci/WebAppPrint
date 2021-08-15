using System.Collections.Generic;

namespace WebAppPrint.Models
{
    public partial class Items : List<Item>
    {
        public Items()
        {
            List<Item> items = new();
            for (int i = 1; i < 101; i++)
            {
                items.Add(new Item(i.ToString()));
            }
            AddRange(items);
        }
    }
}
