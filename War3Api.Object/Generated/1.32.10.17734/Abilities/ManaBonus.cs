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
    public sealed class ManaBonus : Ability
    {
        public ManaBonus(): base(1832012097)
        {
        }

        public ManaBonus(int newId): base(1832012097, newId)
        {
        }

        public ManaBonus(string newRawcode): base(1832012097, newRawcode)
        {
        }

        public ManaBonus(ObjectDatabaseBase db): base(1832012097, db)
        {
        }

        public ManaBonus(int newId, ObjectDatabaseBase db): base(1832012097, newId, db)
        {
        }

        public ManaBonus(string newRawcode, ObjectDatabaseBase db): base(1832012097, newRawcode, db)
        {
        }
    }
}