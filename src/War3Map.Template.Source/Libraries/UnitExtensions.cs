using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Template.Source.Libraries
{
    public static class UnitUtils
    {
        private static float HERO_DROP_DIST = 50; // The radius in which heroes spread out items when they drop them

        public static void UnitDropAllItems(unit unit)
        {
            float ang = 0;
            for (int i = 0; i < 6; i++)
            {
                var x = GetUnitX(unit) + HERO_DROP_DIST * Cos(ang);
                var y = GetUnitY(unit) + HERO_DROP_DIST * Sin(ang);
                var itemToDrop = UnitItemInSlot(unit, i);
                if (BlzGetItemBooleanField(itemToDrop, ITEM_BF_DROPPED_WHEN_CARRIER_DIES) || BlzGetItemBooleanField(itemToDrop, ITEM_BF_CAN_BE_DROPPED))
                {
                    UnitRemoveItem(unit, itemToDrop);
                    SetItemPosition(itemToDrop, x, y);
                }
                ang += ang + (360 * bj_DEGTORAD) / 6;
            }
        }
    }
}
