以下のサイトの構造を参考にして、在庫管理システムのコードを作成してください。
https://github.com/jasontaylordev/CleanArchitecture


## 在庫管理

以下のコードは、在庫管理システムのコマンド、イベント、ポリシー、アグリゲート、およびリードモデルの関係を示しています。


actor user -> Command 在庫の増減入力 -> Aggregate 在庫 -> Event 実在庫の増減
actor user -> Command 在庫の増減入力 -> Aggregate 在庫 -> Event 理論在庫の取得 -> Policy BOM情報の取得 -> Command 在庫増減の入力 → Aggreagete 在庫 → Event 論理在庫の増減
actor user -> Command 棚卸の入力 -> Aggregate 在庫 -> Event 実在庫の上書き
actor user -> Command 月末在庫確定入力 -> Aggregate 在庫 -> Event 月末時点での在庫数の記録
actor user -> Command 在庫表示 -> Aggregete 在庫 -> Event 在庫の取得 -> ReadModel 在庫の表示 -> user -> 在庫のソート入力 -> Aggregete 在庫 -> Event 在庫データのソート -> ReadModel 在庫の表示
actor user -> Command 棚卸実績取得 -> Aggregate 在庫 -> Event 棚卸データの取得 -> ReadModel 棚卸実績の表示
actor uerr -> Command 使用中在庫一覧取得 -> Aggregate 在庫 -> Event 使用中在庫の取得 -> Policy usedCountが1以上かつ在庫が1以上のもの -> Command 使用中在庫一覧表示 -> Aggregate 在庫 -> Event 使用中在庫の取得 -> ReadModel 使用中在庫一覧の表示


## Entity

以下のコードは、在庫管理システムのエンティティを示しています。

```csharp

interface IStockManager
{
    void Increase()

    void Decrease()

}

internal class ItemMaster
        {
            public Guid Id { get; set; }
 
            public string ItemCode { get; }
 
            public string ItemName { get; }
 
            public Classification Classification { get; set; }
 
            public int UnitPrice { get; }
 
 
            public ItemMaster(
                string itemCode,
                string itemName,
                Classification classification,
                int unitPrice
                )
 
            {
                Id = Guid.NewGuid();
                ItemCode = itemCode;
                ItemName = itemName;
                Classification = classification;
                UnitPrice = unitPrice;
            }
 
            public ItemMaster(
                Guid id,
                string itemCode,
                string itemName,
                Classification classification,
                int unitPrice
                )
            {
                Id = id;
                ItemCode = itemCode;
                ItemName = itemName;
                Classification = classification;
                UnitPrice = unitPrice;
            }
        }
        internal class Classification
        {
            public string Item { get; }
 
            public string Asset { get; }
 
            public Classification(string item, string asset)
            {
                Item = item;
                Asset = asset;
            }
        }
 
        internal class InOut
        {
            public ItemMaster ItemMaster { get; }
 
            public Classification Classification { get; }
 
            public string Name { get; }
 
            public int Qty { get; }
 
            public int UnitPrice { get; }
 
            public string LotNo { get; }
 
            public DateTime DateTime { get; }
 
            public InOut(
                ItemMaster itemMaster,
                Classification classification,
                string name,
                int qty,
                int unitPrice,
                string lotNo,
                DateTime dateTime
                )
 
            {
                ItemMaster = itemMaster;
                Classification = classification;
                Name = name;
                Qty = qty;
                UnitPrice = unitPrice;
                LotNo = lotNo;
                DateTime = dateTime;
            }
 
            public InOut(
                ItemMaster itemMaster,
                Classification classification,
                string name,
                int qty,
                int unitPrice,
                string lotNo
                )
            {
                ItemMaster = itemMaster;
                Classification = classification;
                Name = name;
                Qty = qty;
                UnitPrice = unitPrice;
                LotNo = lotNo;
                DateTime = DateTime.Now;
            }
 
        }
 
        internal class Inventory
        {
            public ItemMaster ItemMaster;
 
            public string LotNo;
 
            public int Qty;
 
            public int Price;
 
            public int UsedCount; // 出庫の回数分カウントアップする。
 
            public Inventory(ItemMaster itemMaster, string lotNo, int qty, int price, int usedCount)
            {
                ItemMaster = itemMaster;
                LotNo = lotNo;
                Qty = qty;
                Price = price;
                UsedCount = usedCount;
            }
        }
```