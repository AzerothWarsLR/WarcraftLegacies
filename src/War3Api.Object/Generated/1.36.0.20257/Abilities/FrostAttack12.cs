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
    public sealed class FrostAttack12 : Ability
    {
        public FrostAttack12(): base(846358081)
        {
        }

        public FrostAttack12(int newId): base(846358081, newId)
        {
        }

        public FrostAttack12(string newRawcode): base(846358081, newRawcode)
        {
        }

        public FrostAttack12(ObjectDatabaseBase db): base(846358081, db)
        {
        }

        public FrostAttack12(int newId, ObjectDatabaseBase db): base(846358081, newId, db)
        {
        }

        public FrostAttack12(string newRawcode, ObjectDatabaseBase db): base(846358081, newRawcode, db)
        {
        }
    }
}