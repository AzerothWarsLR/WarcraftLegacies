using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemAuraWarDrums : Ability
    {
        public ItemAuraWarDrums(): base(1685539137)
        {
        }

        public ItemAuraWarDrums(int newId): base(1685539137, newId)
        {
        }

        public ItemAuraWarDrums(string newRawcode): base(1685539137, newRawcode)
        {
        }

        public ItemAuraWarDrums(ObjectDatabase db): base(1685539137, db)
        {
        }

        public ItemAuraWarDrums(int newId, ObjectDatabase db): base(1685539137, newId, db)
        {
        }

        public ItemAuraWarDrums(string newRawcode, ObjectDatabase db): base(1685539137, newRawcode, db)
        {
        }
    }
}