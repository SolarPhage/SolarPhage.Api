module Character.Types

type CharacterInventoryItem = {
    Item : Item.Types.Item
    Count : int
}

type Character = {
    Id: int
    Name: string
    Level: int
    Enabled: bool
    Inventory: List<CharacterInventoryItem>
}