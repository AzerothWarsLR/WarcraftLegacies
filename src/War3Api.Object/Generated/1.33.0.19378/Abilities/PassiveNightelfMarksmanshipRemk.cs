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
    public sealed class PassiveNightelfMarksmanshipRemk : Ability
    {
        public PassiveNightelfMarksmanshipRemk(): base(1802331457)
        {
        }

        public PassiveNightelfMarksmanshipRemk(int newId): base(1802331457, newId)
        {
        }

        public PassiveNightelfMarksmanshipRemk(string newRawcode): base(1802331457, newRawcode)
        {
        }

        public PassiveNightelfMarksmanshipRemk(ObjectDatabaseBase db): base(1802331457, db)
        {
        }

        public PassiveNightelfMarksmanshipRemk(int newId, ObjectDatabaseBase db): base(1802331457, newId, db)
        {
        }

        public PassiveNightelfMarksmanshipRemk(string newRawcode, ObjectDatabaseBase db): base(1802331457, newRawcode, db)
        {
        }
    }
}