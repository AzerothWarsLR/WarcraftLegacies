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
    public sealed class FlameStrikeImprovedCreep : Ability
    {
        public FlameStrikeImprovedCreep(): base(1936084545)
        {
        }

        public FlameStrikeImprovedCreep(int newId): base(1936084545, newId)
        {
        }

        public FlameStrikeImprovedCreep(string newRawcode): base(1936084545, newRawcode)
        {
        }

        public FlameStrikeImprovedCreep(ObjectDatabaseBase db): base(1936084545, db)
        {
        }

        public FlameStrikeImprovedCreep(int newId, ObjectDatabaseBase db): base(1936084545, newId, db)
        {
        }

        public FlameStrikeImprovedCreep(string newRawcode, ObjectDatabaseBase db): base(1936084545, newRawcode, db)
        {
        }
    }
}