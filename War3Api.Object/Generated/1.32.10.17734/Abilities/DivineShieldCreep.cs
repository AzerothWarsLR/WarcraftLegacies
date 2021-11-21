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
    public sealed class DivineShieldCreep : Ability
    {
        public DivineShieldCreep(): base(1935950657)
        {
        }

        public DivineShieldCreep(int newId): base(1935950657, newId)
        {
        }

        public DivineShieldCreep(string newRawcode): base(1935950657, newRawcode)
        {
        }

        public DivineShieldCreep(ObjectDatabaseBase db): base(1935950657, db)
        {
        }

        public DivineShieldCreep(int newId, ObjectDatabaseBase db): base(1935950657, newId, db)
        {
        }

        public DivineShieldCreep(string newRawcode, ObjectDatabaseBase db): base(1935950657, newRawcode, db)
        {
        }
    }
}