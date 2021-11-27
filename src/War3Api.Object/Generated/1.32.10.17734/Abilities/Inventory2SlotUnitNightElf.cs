using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
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

        public Inventory2SlotUnitNightElf(ObjectDatabaseBase db): base(1852139841, db)
        {
        }

        public Inventory2SlotUnitNightElf(int newId, ObjectDatabaseBase db): base(1852139841, newId, db)
        {
        }

        public Inventory2SlotUnitNightElf(string newRawcode, ObjectDatabaseBase db): base(1852139841, newRawcode, db)
        {
        }
    }
}