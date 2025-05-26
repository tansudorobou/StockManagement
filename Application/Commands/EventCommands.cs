using System;
using Domain.Entities;

namespace Application.Commands
{
    // 在庫増減イベント用コマンド
    public class StockChangedCommand
    {
        public Guid InventoryId { get; }
        public int ChangedQty { get; }
        public ChangeType ChangeType { get; }
        public StockChangedCommand(Guid inventoryId, int changedQty, ChangeType changeType)
        {
            InventoryId = inventoryId;
            ChangedQty = changedQty;
            ChangeType = changeType;
        }
    }

    // 棚卸イベント用コマンド
    public class InventoryCountedCommand
    {
        public Guid InventoryId { get; }
        public int CountedQty { get; }
        public InventoryCountedCommand(Guid inventoryId, int countedQty)
        {
            InventoryId = inventoryId;
            CountedQty = countedQty;
        }
    }

    // 月末在庫確定イベント用コマンド
    public class MonthEndInventoryFixedCommand
    {
        public Guid InventoryId { get; }
        public int QtyAtMonthEnd { get; }
        public DateTime MonthEnd { get; }
        public MonthEndInventoryFixedCommand(Guid inventoryId, int qtyAtMonthEnd, DateTime monthEnd)
        {
            InventoryId = inventoryId;
            QtyAtMonthEnd = qtyAtMonthEnd;
            MonthEnd = monthEnd;
        }
    }
}
