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
    public sealed class Inventory2SlotUnitOrc : Ability
    {
        public Inventory2SlotUnitOrc(): base(1852795201)
        {
        }

        public Inventory2SlotUnitOrc(int newId): base(1852795201, newId)
        {
        }

        public Inventory2SlotUnitOrc(string newRawcode): base(1852795201, newRawcode)
        {
        }

        public Inventory2SlotUnitOrc(ObjectDatabaseBase db): base(1852795201, db)
        {
        }

        public Inventory2SlotUnitOrc(int newId, ObjectDatabaseBase db): base(1852795201, newId, db)
        {
        }

        public Inventory2SlotUnitOrc(string newRawcode, ObjectDatabaseBase db): base(1852795201, newRawcode, db)
        {
        }
    }
}