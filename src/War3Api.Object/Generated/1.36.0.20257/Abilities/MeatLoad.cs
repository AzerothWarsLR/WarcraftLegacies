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
    public sealed class MeatLoad : Ability
    {
        public MeatLoad(): base(1818586433)
        {
        }

        public MeatLoad(int newId): base(1818586433, newId)
        {
        }

        public MeatLoad(string newRawcode): base(1818586433, newRawcode)
        {
        }

        public MeatLoad(ObjectDatabaseBase db): base(1818586433, db)
        {
        }

        public MeatLoad(int newId, ObjectDatabaseBase db): base(1818586433, newId, db)
        {
        }

        public MeatLoad(string newRawcode, ObjectDatabaseBase db): base(1818586433, newRawcode, db)
        {
        }
    }
}