using System.Text.Json.Serialization;
using Domain.SeedWork;

namespace Domain.Model
{
    public class ItemMaster : BaseEntity
    {
        public string ItemCode { get; }
        public string ItemName { get; }
        public Classification Classification { get; }
        public int UnitPrice { get; }
        public ItemMaster(string itemCode, string itemName, Classification classification, int unitPrice)
            : base()
        {
            ItemCode = itemCode;
            ItemName = itemName;
            Classification = classification;
            UnitPrice = unitPrice;
        }
        [JsonConstructor]
        public ItemMaster(Guid id, DateTime createdAt, DateTime updatedAt, string itemCode, string itemName, Classification classification, int unitPrice)
            : base(id, createdAt, updatedAt)
        {
            ItemCode = itemCode;
            ItemName = itemName;
            Classification = classification;
            UnitPrice = unitPrice;
        }
    }

}