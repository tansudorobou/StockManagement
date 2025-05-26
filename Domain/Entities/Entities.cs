namespace Domain.Entities {
    public abstract class BaseEntity {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        protected BaseEntity() {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        protected BaseEntity(Guid id, DateTime createdAt, DateTime updatedAt) {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
        public void SetUpdated() {
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public class ItemMaster : BaseEntity {
        public string ItemCode { get; }
        public string ItemName { get; }
        public Classification Classification { get; }
        public int UnitPrice { get; }
        public ItemMaster(string itemCode, string itemName, Classification classification, int unitPrice)
            : base() {
            ItemCode = itemCode;
            ItemName = itemName;
            Classification = classification;
            UnitPrice = unitPrice;
        }
        public ItemMaster(Guid id, DateTime createdAt, DateTime updatedAt, string itemCode, string itemName, Classification classification, int unitPrice)
            : base(id, createdAt, updatedAt) {
            ItemCode = itemCode;
            ItemName = itemName;
            Classification = classification;
            UnitPrice = unitPrice;
        }
    }

    public class Classification {
        public string Item { get; }
        public string Asset { get; }
        public Classification(string item, string asset) {
            Item = item;
            Asset = asset;
        }
        public override bool Equals(object? obj) => obj is Classification c && Item == c.Item && Asset == c.Asset;
        public override int GetHashCode() => (Item, Asset).GetHashCode();
    }

    public class InOut : BaseEntity {
        public ItemMaster ItemMaster { get; }
        public Classification Classification { get; }
        public string Name { get; }
        public int Qty { get; }
        public int UnitPrice { get; }
        public string LotNo { get; }
        public DateTimeOffset DateTime { get; }
        public InOut(ItemMaster itemMaster, Classification classification, string name, int qty, int unitPrice, string lotNo, DateTimeOffset dateTime)
            : base() {
            ItemMaster = itemMaster;
            Classification = classification;
            Name = name;
            Qty = qty;
            UnitPrice = unitPrice;
            LotNo = lotNo;
            DateTime = dateTime;
        }
        public InOut(Guid id, DateTime createdAt, DateTime updatedAt, ItemMaster itemMaster, Classification classification, string name, int qty, int unitPrice, string lotNo, DateTimeOffset dateTime)
            : base(id, createdAt, updatedAt) {
            ItemMaster = itemMaster;
            Classification = classification;
            Name = name;
            Qty = qty;
            UnitPrice = unitPrice;
            LotNo = lotNo;
            DateTime = dateTime;
        }
    }

    public class Inventory : BaseEntity {
        public ItemMaster ItemMaster { get; }
        public string LotNo { get; }
        public int Qty { get; private set; }
        public int Price { get; }
        public int UsedCount { get; private set; }
        public Inventory(ItemMaster itemMaster, string lotNo, int qty, int price, int usedCount)
            : base() {
            ItemMaster = itemMaster;
            LotNo = lotNo;
            Qty = qty;
            Price = price;
            UsedCount = usedCount;
        }
        public Inventory(Guid id, DateTime createdAt, DateTime updatedAt, ItemMaster itemMaster, string lotNo, int qty, int price, int usedCount)
            : base(id, createdAt, updatedAt) {
            ItemMaster = itemMaster;
            LotNo = lotNo;
            Qty = qty;
            Price = price;
            UsedCount = usedCount;
        }
        // 在庫の増減はドメインサービスやアプリケーション層で管理するため、
        // ここではQtyやUsedCountの直接的な変更メソッドは持たない
        // 必要に応じて内部的な状態変更用のメソッドはinternal/protectedで用意してもよい
    }
}
