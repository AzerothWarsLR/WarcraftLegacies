using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Inventory2SlotUnitNightElf : Ability
    {
        public Inventory2SlotUnitNightElf(): base(1852139841)
        {
        }

        public Inventory2SlotUnitNightElf(int newId): base(1852139841, newId)
        {
        }

        public Inventory2SlotUnitNightElf(string newRawcode): base(1852139841, newRawcode)
        {
        }

        public Inventory2SlotUnitNightElf(ObjectDatabase db): base(1852139841, db)
        {
        }

        public Inventory2SlotUnitNightElf(int newId, ObjectDatabase db): base(1852139841, newId, db)
        {
        }

        public Inventory2SlotUnitNightElf(string newRawcode, ObjectDatabase db): base(1852139841, newRawcode, db)
        {
        }
    }
}