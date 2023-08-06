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
    public sealed class CleavingAttackCreep : Ability
    {
        public CleavingAttackCreep(): base(1701004097)
        {
        }

        public CleavingAttackCreep(int newId): base(1701004097, newId)
        {
        }

        public CleavingAttackCreep(string newRawcode): base(1701004097, newRawcode)
        {
        }

        public CleavingAttackCreep(ObjectDatabaseBase db): base(1701004097, db)
        {
        }

        public CleavingAttackCreep(int newId, ObjectDatabaseBase db): base(1701004097, newId, db)
        {
        }

        public CleavingAttackCreep(string newRawcode, ObjectDatabaseBase db): base(1701004097, newRawcode, db)
        {
        }
    }
}