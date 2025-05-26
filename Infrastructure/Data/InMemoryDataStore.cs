using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.Data {
    // InMemoryで在庫情報と入出庫情報を保持するデータストア
    public class InMemoryDataStore {
        // 在庫情報リスト
        public List<Inventory> Inventories { get; } = new List<Inventory>();
        // 入出庫履歴リスト
        public List<InOut> InOuts { get; } = new List<InOut>();

        public InMemoryDataStore() {
            // 仮の初期データ投入
            var classification = new Domain.Entities.Classification("部品", "資産");
            var item1 = new Domain.Entities.ItemMaster("ITEM001", "ねじ", classification, 10);
            var item2 = new Domain.Entities.ItemMaster("ITEM002", "ナット", classification, 20);

            Inventories.Add(new Domain.Entities.Inventory(item1, "LOT001", 100, 10, 0));
            Inventories.Add(new Domain.Entities.Inventory(item2, "LOT002", 50, 20, 0));

            InOuts.Add(new Domain.Entities.InOut(item1, classification, "入庫", 100, 10, "LOT001", DateTimeOffset.Now.AddDays(-2)));
            InOuts.Add(new Domain.Entities.InOut(item2, classification, "入庫", 50, 20, "LOT002", DateTimeOffset.Now.AddDays(-1)));
        }
    }
}
