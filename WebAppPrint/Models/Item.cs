using System;

namespace WebAppPrint.Models
{
    public record Item
    {
        public Item(string name)
        {
            Uuid = Guid.NewGuid();
            Name = name;
        }
        public Guid Uuid { get; init; }
        public string Name { get; init; }
    }
}
