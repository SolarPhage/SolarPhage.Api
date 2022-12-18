module Shop.Types

open Item.Types

type ShopItem = {
    ItemInfo : Item
    AmountForSale : int
    CostPerItem : int
}