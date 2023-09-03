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
    public sealed class PassiveUndeadGhoulFrenzyRugf : Ability
    {
        public PassiveUndeadGhoulFrenzyRugf(): base(1718056257)
        {
        }

        public PassiveUndeadGhoulFrenzyRugf(int newId): base(1718056257, newId)
        {
        }

        public PassiveUndeadGhoulFrenzyRugf(string newRawcode): base(1718056257, newRawcode)
        {
        }

        public PassiveUndeadGhoulFrenzyRugf(ObjectDatabaseBase db): base(1718056257, db)
        {
        }

        public PassiveUndeadGhoulFrenzyRugf(int newId, ObjectDatabaseBase db): base(1718056257, newId, db)
        {
        }

        public PassiveUndeadGhoulFrenzyRugf(string newRawcode, ObjectDatabaseBase db): base(1718056257, newRawcode, db)
        {
        }
    }
}