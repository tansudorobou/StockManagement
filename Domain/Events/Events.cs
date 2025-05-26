using Domain.Entities;

namespace Domain.Events
{
    public abstract class BaseEvent
    {
        public Guid Id { get; protected set; }
        public DateTime OccurredAt { get; protected set; }
        protected BaseEvent()
        {
            Id = Guid.NewGuid();
            OccurredAt = DateTime.UtcNow;
        }
        protected BaseEvent(Guid id, DateTime occurredAt)
        {
            Id = id;
            OccurredAt = occurredAt;
        }
    }

    // 在庫増減イベント
    public class StockChangedEvent : BaseEvent
    {
        public Guid InventoryId { get; }
        public int ChangedQty { get; }
        public ChangeType ChangeType { get; }
        public StockChangedEvent(Guid inventoryId, int changedQty, ChangeType changeType)
            : base()
        {
            InventoryId = inventoryId;
            ChangedQty = changedQty;
            ChangeType = changeType;
        }
    }

    // 棚卸イベント
    public class InventoryCountedEvent : BaseEvent
    {
        public Guid InventoryId { get; }
        public int CountedQty { get; }
        public InventoryCountedEvent(Guid inventoryId, int countedQty)
            : base()
        {
            InventoryId = inventoryId;
            CountedQty = countedQty;
        }
    }

    // 月末在庫確定イベント
    public class MonthEndInventoryFixedEvent : BaseEvent
    {
        public Guid InventoryId { get; }
        public int QtyAtMonthEnd { get; }
        public DateTime MonthEnd { get; }
        public MonthEndInventoryFixedEvent(Guid inventoryId, int qtyAtMonthEnd, DateTime monthEnd)
            : base()
        {
            InventoryId = inventoryId;
            QtyAtMonthEnd = qtyAtMonthEnd;
            MonthEnd = monthEnd;
        }
    }
}
