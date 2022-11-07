using MacroTools.Wrappers;
using System.Collections.Generic;
using static War3Api.Common;

namespace MacroTools.Extensions
{
    /// <summary>
    /// Provides a helpful set of extension methods for native Warcraft 3 <see cref="rect"/>s.
    /// </summary>
    public static class RectExtensions
    {
        /// <summary>
        /// Renders all units inside the specified <paramref name="area"/> that belong to <paramref name="owningUnitsPlayer"/> invulnerable/>
        /// </summary>
        /// <param name="area"></param>
        /// <param name="owningUnitsPlayer"></param>
        /// <returns>A list of all units found in the specified area that belong to <paramref name="owningUnitsPlayer"/></returns>
        // Todo: Rename to something more sensible
        public static List<unit> MakeUnitsInvulnerable(this rect area, player owningUnitsPlayer)
        {        
            var shenGroup = CreateGroup();
            List<unit> groupUnits = new();
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
                if (GetOwningPlayer(unit) == owningUnitsPlayer)
                {
                    SetUnitInvulnerable(unit, true);
                    groupUnits.Add(unit);
                }
                GroupRemoveUnit(shenGroup, unit);               
            }
            return groupUnits;
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
