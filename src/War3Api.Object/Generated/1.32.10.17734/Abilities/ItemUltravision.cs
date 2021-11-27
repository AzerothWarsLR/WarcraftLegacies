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
    public sealed class ItemUltravision : Ability
    {
        public ItemUltravision(): base(1987397953)
        {
        }

        public ItemUltravision(int newId): base(1987397953, newId)
        {
        }

        public ItemUltravision(string newRawcode): base(1987397953, newRawcode)
        {
        }

        public ItemUltravision(ObjectDatabaseBase db): base(1987397953, db)
        {
        }

        public ItemUltravision(int newId, ObjectDatabaseBase db): base(1987397953, newId, db)
        {
        }

        public ItemUltravision(string newRawcode, ObjectDatabaseBase db): base(1987397953, newRawcode, db)
        {
        }
    }
}