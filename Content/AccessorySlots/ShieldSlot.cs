﻿using Terraria;
using Terraria.ID;

namespace AccessoriesPlus.Content.AccessorySlots;
internal class ShieldSlot : AbstractAccessorySlot
{
    public override int FunctionalItemID => ItemID.CobaltShield;
    public override int VanityItemID => ItemID.AnkhShield;

    public override bool IsValidItem(Item item)
    {
        return item.shieldSlot > 0;
    }
}