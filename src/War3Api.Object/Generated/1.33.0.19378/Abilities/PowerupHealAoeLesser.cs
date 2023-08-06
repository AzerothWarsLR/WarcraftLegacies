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
    public sealed class PowerupHealAoeLesser : Ability
    {
        public PowerupHealAoeLesser(): base(828919873)
        {
        }

        public PowerupHealAoeLesser(int newId): base(828919873, newId)
        {
        }

        public PowerupHealAoeLesser(string newRawcode): base(828919873, newRawcode)
        {
        }

        public PowerupHealAoeLesser(ObjectDatabaseBase db): base(828919873, db)
        {
        }

        public PowerupHealAoeLesser(int newId, ObjectDatabaseBase db): base(828919873, newId, db)
        {
        }

        public PowerupHealAoeLesser(string newRawcode, ObjectDatabaseBase db): base(828919873, newRawcode, db)
        {
        }
    }
}