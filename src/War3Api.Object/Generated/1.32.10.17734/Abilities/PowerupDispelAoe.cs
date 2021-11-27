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
    public sealed class PowerupDispelAoe : Ability
    {
        public PowerupDispelAoe(): base(1768181825)
        {
        }

        public PowerupDispelAoe(int newId): base(1768181825, newId)
        {
        }

        public PowerupDispelAoe(string newRawcode): base(1768181825, newRawcode)
        {
        }

        public PowerupDispelAoe(ObjectDatabaseBase db): base(1768181825, db)
        {
        }

        public PowerupDispelAoe(int newId, ObjectDatabaseBase db): base(1768181825, newId, db)
        {
        }

        public PowerupDispelAoe(string newRawcode, ObjectDatabaseBase db): base(1768181825, newRawcode, db)
        {
        }
    }
}