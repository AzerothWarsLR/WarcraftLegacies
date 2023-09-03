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
    public sealed class AgilityBonus2 : Ability
    {
        public AgilityBonus2(): base(845236545)
        {
        }

        public AgilityBonus2(int newId): base(845236545, newId)
        {
        }

        public AgilityBonus2(string newRawcode): base(845236545, newRawcode)
        {
        }

        public AgilityBonus2(ObjectDatabaseBase db): base(845236545, db)
        {
        }

        public AgilityBonus2(int newId, ObjectDatabaseBase db): base(845236545, newId, db)
        {
        }

        public AgilityBonus2(string newRawcode, ObjectDatabaseBase db): base(845236545, newRawcode, db)
        {
        }
    }
}