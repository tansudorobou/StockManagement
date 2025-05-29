using System.Text.Json.Serialization;
using Domain.SeedWork;

namespace Domain.Model
{
    public class InOut : BaseEntity
    {
        public ItemMaster ItemMaster { get; }
        public Classification Classification { get; }
        public string Name { get; }
        public int Qty { get; }
        public int UnitPrice { get; }
        public string LotNo { get; }
        public DateTimeOffset DateTime { get; }
        public InOut(ItemMaster itemMaster, Classification classification, string name, int qty, int unitPrice, string lotNo, DateTimeOffset dateTime)
            : base()
        {
            ItemMaster = itemMaster;
            Classification = classification;
            Name = name;
            Qty = qty;
            UnitPrice = unitPrice;
            LotNo = lotNo;
            DateTime = dateTime;
        }

        [JsonConstructor]
        public InOut(Guid id, DateTime createdAt, DateTime updatedAt, ItemMaster itemMaster, Classification classification, string name, int qty, int unitPrice, string lotNo, DateTimeOffset dateTime)
            : base(id, createdAt, updatedAt)
        {
            ItemMaster = itemMaster;
            Classification = classification;
            Name = name;
            Qty = qty;
            UnitPrice = unitPrice;
            LotNo = lotNo;
            DateTime = dateTime;
        }
    }

}