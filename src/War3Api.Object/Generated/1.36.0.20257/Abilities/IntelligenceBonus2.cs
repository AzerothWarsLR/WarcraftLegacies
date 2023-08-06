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
    public sealed class IntelligenceBonus2 : Ability
    {
        public IntelligenceBonus2(): base(845760833)
        {
        }

        public IntelligenceBonus2(int newId): base(845760833, newId)
        {
        }

        public IntelligenceBonus2(string newRawcode): base(845760833, newRawcode)
        {
        }

        public IntelligenceBonus2(ObjectDatabaseBase db): base(845760833, db)
        {
        }

        public IntelligenceBonus2(int newId, ObjectDatabaseBase db): base(845760833, newId, db)
        {
        }

        public IntelligenceBonus2(string newRawcode, ObjectDatabaseBase db): base(845760833, newRawcode, db)
        {
        }
    }
}