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
    public sealed class _200ManaBonus : Ability
    {
        public _200ManaBonus(): base(1832012097)
        {
        }

        public _200ManaBonus(int newId): base(1832012097, newId)
        {
        }

        public _200ManaBonus(string newRawcode): base(1832012097, newRawcode)
        {
        }

        public _200ManaBonus(ObjectDatabaseBase db): base(1832012097, db)
        {
        }

        public _200ManaBonus(int newId, ObjectDatabaseBase db): base(1832012097, newId, db)
        {
        }

        public _200ManaBonus(string newRawcode, ObjectDatabaseBase db): base(1832012097, newRawcode, db)
        {
        }
    }
}