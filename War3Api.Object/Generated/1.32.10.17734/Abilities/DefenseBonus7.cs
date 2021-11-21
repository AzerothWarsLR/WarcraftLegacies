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
    public sealed class DefenseBonus7 : Ability
    {
        public DefenseBonus7(): base(929319233)
        {
        }

        public DefenseBonus7(int newId): base(929319233, newId)
        {
        }

        public DefenseBonus7(string newRawcode): base(929319233, newRawcode)
        {
        }

        public DefenseBonus7(ObjectDatabaseBase db): base(929319233, db)
        {
        }

        public DefenseBonus7(int newId, ObjectDatabaseBase db): base(929319233, newId, db)
        {
        }

        public DefenseBonus7(string newRawcode, ObjectDatabaseBase db): base(929319233, newRawcode, db)
        {
        }
    }
}