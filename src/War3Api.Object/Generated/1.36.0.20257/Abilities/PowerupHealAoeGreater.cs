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
    public sealed class PowerupHealAoeGreater : Ability
    {
        public PowerupHealAoeGreater(): base(862474305)
        {
        }

        public PowerupHealAoeGreater(int newId): base(862474305, newId)
        {
        }

        public PowerupHealAoeGreater(string newRawcode): base(862474305, newRawcode)
        {
        }

        public PowerupHealAoeGreater(ObjectDatabaseBase db): base(862474305, db)
        {
        }

        public PowerupHealAoeGreater(int newId, ObjectDatabaseBase db): base(862474305, newId, db)
        {
        }

        public PowerupHealAoeGreater(string newRawcode, ObjectDatabaseBase db): base(862474305, newRawcode, db)
        {
        }
    }
}