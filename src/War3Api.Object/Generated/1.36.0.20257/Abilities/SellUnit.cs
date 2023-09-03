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
    public sealed class SellUnit : Ability
    {
        public SellUnit(): base(1685418817)
        {
        }

        public SellUnit(int newId): base(1685418817, newId)
        {
        }

        public SellUnit(string newRawcode): base(1685418817, newRawcode)
        {
        }

        public SellUnit(ObjectDatabaseBase db): base(1685418817, db)
        {
        }

        public SellUnit(int newId, ObjectDatabaseBase db): base(1685418817, newId, db)
        {
        }

        public SellUnit(string newRawcode, ObjectDatabaseBase db): base(1685418817, newRawcode, db)
        {
        }
    }
}