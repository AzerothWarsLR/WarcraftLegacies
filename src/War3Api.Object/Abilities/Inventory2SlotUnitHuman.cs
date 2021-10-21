using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class Inventory2SlotUnitHuman : Ability
    {
        public Inventory2SlotUnitHuman(): base(1852336449)
        {
        }

        public Inventory2SlotUnitHuman(int newId): base(1852336449, newId)
        {
        }

        public Inventory2SlotUnitHuman(string newRawcode): base(1852336449, newRawcode)
        {
        }

        public Inventory2SlotUnitHuman(ObjectDatabase db): base(1852336449, db)
        {
        }

        public Inventory2SlotUnitHuman(int newId, ObjectDatabase db): base(1852336449, newId, db)
        {
        }

        public Inventory2SlotUnitHuman(string newRawcode, ObjectDatabase db): base(1852336449, newRawcode, db)
        {
        }
    }
}