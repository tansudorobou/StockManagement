using System.Text.Json.Serialization;
using Domain.SeedWork;

namespace Domain.Model
{
    public class Inventory : BaseEntity
    {
        public ItemMaster ItemMaster { get; }
        public string LotNo { get; }
        public int Qty { get; private set; }
        public int Price { get; }
        public int UsedCount { get; private set; }
        public Inventory(ItemMaster itemMaster, string lotNo, int qty, int price, int usedCount)
            : base()
        {
            ItemMaster = itemMaster;
            LotNo = lotNo;
            Qty = qty;
            Price = price;
            UsedCount = usedCount;
        }

        [JsonConstructor]
        public Inventory(Guid id, DateTime createdAt, DateTime updatedAt, ItemMaster itemMaster, string lotNo, int qty, int price, int usedCount)
            : base(id, createdAt, updatedAt)
        {
            ItemMaster = itemMaster;
            LotNo = lotNo;
            Qty = qty;
            Price = price;
            UsedCount = usedCount;
        }
    }
}