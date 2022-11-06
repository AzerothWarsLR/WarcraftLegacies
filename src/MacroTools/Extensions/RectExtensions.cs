using MacroTools.Wrappers;
using static War3Api.Common;

namespace MacroTools.Extensions
{
    /// <summary>
    /// Provides a helpful set of extension methods for <see cref="rect"/>s.
    /// </summary>
    public static class RectExtensions
    {
        /// <summary>
        /// Renders all units inside the specified area invulnerable/>
        /// </summary>
        /// <param name="area"></param>
        public static void MakeUnitsInvulnerable(this rect area)
        {
            var shenGroup = CreateGroup();
            GroupEnumUnitsInRect(shenGroup, area, null);
            bool execute = true;
            while (execute)
            {
                var unit = FirstOfGroup(shenGroup);
                if (unit == null)
                {
                    execute = false;
                    continue;
                }
                if (GetOwningPlayer(unit) == Player(GetPlayerNeutralPassive()))
                {
                    SetUnitInvulnerable(unit, true);
                }
                GroupRemoveUnit(shenGroup, unit);
            }
        }

        /// <summary>
        /// Changes the owner of all units inside the specified <paramref name="area"/> from <paramref name="owningPlayer"/> to <paramref name="newOwningPlayer"/> 
        /// and renders all non-building units invisible.
        /// </summary>
        /// <param name="area"></param>
        /// <param name="owningPlayer"></param>
        /// <param name="newOwningPlayer"></param>
        public static void ChangeUnitsOwningPlayer(this rect area, player owningPlayer, player newOwningPlayer)
        {
            foreach (var unit in new GroupWrapper().EnumUnitsInRect(area).EmptyToList())
            {
                if (unit.OwningPlayer() == owningPlayer)
                {
                    unit.SetOwner(newOwningPlayer);
                    if (!IsUnitType(unit, UNIT_TYPE_STRUCTURE))
                    {
                        unit.Show(false);
                    }
                }
            }
        }
    }
}
