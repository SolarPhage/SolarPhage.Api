module Character.Types

type CharacterInventoryItem = {
    Item : Item.Types.Item
    Count : int
}

type CharacterReadSql = {
    CharacterId : int
    UserId : string
}

type CharacterWriteSql = {
    UserId : string
}

type Character = {
    Id: int
    UserId: string
    Name: string
    Level: int
    Enabled: bool
    Inventory: List<CharacterInventoryItem>
}