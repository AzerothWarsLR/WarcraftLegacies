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
    public sealed class MeatDrop : Ability
    {
        public MeatDrop(): base(1684368705)
        {
        }

        public MeatDrop(int newId): base(1684368705, newId)
        {
        }

        public MeatDrop(string newRawcode): base(1684368705, newRawcode)
        {
        }

        public MeatDrop(ObjectDatabaseBase db): base(1684368705, db)
        {
        }

        public MeatDrop(int newId, ObjectDatabaseBase db): base(1684368705, newId, db)
        {
        }

        public MeatDrop(string newRawcode, ObjectDatabaseBase db): base(1684368705, newRawcode, db)
        {
        }
    }
}