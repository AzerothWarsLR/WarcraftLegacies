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
    public sealed class DefenseBonus10 : Ability
    {
        public DefenseBonus10(): base(811878721)
        {
        }

        public DefenseBonus10(int newId): base(811878721, newId)
        {
        }

        public DefenseBonus10(string newRawcode): base(811878721, newRawcode)
        {
        }

        public DefenseBonus10(ObjectDatabaseBase db): base(811878721, db)
        {
        }

        public DefenseBonus10(int newId, ObjectDatabaseBase db): base(811878721, newId, db)
        {
        }

        public DefenseBonus10(string newRawcode, ObjectDatabaseBase db): base(811878721, newRawcode, db)
        {
        }
    }
}