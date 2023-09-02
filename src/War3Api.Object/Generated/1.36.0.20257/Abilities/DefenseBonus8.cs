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
    public sealed class DefenseBonus8 : Ability
    {
        public DefenseBonus8(): base(946096449)
        {
        }

        public DefenseBonus8(int newId): base(946096449, newId)
        {
        }

        public DefenseBonus8(string newRawcode): base(946096449, newRawcode)
        {
        }

        public DefenseBonus8(ObjectDatabaseBase db): base(946096449, db)
        {
        }

        public DefenseBonus8(int newId, ObjectDatabaseBase db): base(946096449, newId, db)
        {
        }

        public DefenseBonus8(string newRawcode, ObjectDatabaseBase db): base(946096449, newRawcode, db)
        {
        }
    }
}