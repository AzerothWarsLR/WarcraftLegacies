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
    public sealed class CairneShockWave : Ability
    {
        public CairneShockWave(): base(846417729)
        {
        }

        public CairneShockWave(int newId): base(846417729, newId)
        {
        }

        public CairneShockWave(string newRawcode): base(846417729, newRawcode)
        {
        }

        public CairneShockWave(ObjectDatabaseBase db): base(846417729, db)
        {
        }

        public CairneShockWave(int newId, ObjectDatabaseBase db): base(846417729, newId, db)
        {
        }

        public CairneShockWave(string newRawcode, ObjectDatabaseBase db): base(846417729, newRawcode, db)
        {
        }
    }
}