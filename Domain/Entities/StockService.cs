namespace Domain.Entities {
    public enum ChangeType {
        Increase,
        Decrease
    }

    public class ChangeStockCommand {
        public ItemMaster Item { get; }
        public string LotNo { get; }
        public int Qty { get; }
        public ChangeType Type { get; }
        public ChangeStockCommand(ItemMaster item, string lotNo, int qty, ChangeType type) {
            Item = item;
            LotNo = lotNo;
            Qty = qty;
            Type = type;
        }
    }

    public interface IStockService {
        void ChangeStock(ChangeStockCommand cmd);
    }
}
