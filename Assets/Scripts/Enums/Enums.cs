public enum InventoryLoaction
{
    Player,
    Chest,
    Count
}

public enum ToolEffect
{
    None,
    Watering,
    
}

public enum Direction
{
    Up,
    Down,
    Right,
    Left,
    None,
}

public enum ItemType
{
    Seed,
    Commodity,
    WateringTool,
    HoeingTool,
    ChoppingTool,
    BreakingTool,
    ReapingTool,
    CollectingTool,
    ReapableScenary,
    Furniture,
    None,
    Count, // An enum for count the number of item type
}

public enum AnimationName
{
    idleDown,
    idleUp,
    idleLeft,
    idleRight,
    walkUp,
    walkDown,
    walkRight,
    walkLeft,
    runUp,
    runDown,
    runLeft,
    runRight,
    useToolUp,
    useToolDown,
    useToolLeft,
    useToolRight,
    swingToolUp,
    swingToolDown,
    swingToolLeft,
    swingToolRight,
    liftToolUp,
    liftToolDown,
    liftToolLeft,
    liftToolRight,
    holdToolUp,
    holdToolDown,
    holdToolLeft,
    holdToolRight,
    pickUp,
    pickDown,
    pickLeft,
    pickRight,
    Count
}

public enum CharacterPartAnimator
{
    body,
    arms,
    hair,
    tool,
    hat,
    Count
}

public enum PartVariantColour 
{
    none,
    Count
}

public enum PartVariantType
{
    none,
    carry,
    hoe,
    pickaxe,
    axe,
    scythe,
    wateringCan,
    Count
}