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
    public sealed class AttackBonus20 : Ability
    {
        public AttackBonus20(): base(2020886849)
        {
        }

        public AttackBonus20(int newId): base(2020886849, newId)
        {
        }

        public AttackBonus20(string newRawcode): base(2020886849, newRawcode)
        {
        }

        public AttackBonus20(ObjectDatabaseBase db): base(2020886849, db)
        {
        }

        public AttackBonus20(int newId, ObjectDatabaseBase db): base(2020886849, newId, db)
        {
        }

        public AttackBonus20(string newRawcode, ObjectDatabaseBase db): base(2020886849, newRawcode, db)
        {
        }
    }
}