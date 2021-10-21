using System;
using System.Collections.Generic;
using System.Linq;
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

        public PassiveUndeadGhoulFrenzyRugf(ObjectDatabase db): base(1718056257, db)
        {
        }

        public PassiveUndeadGhoulFrenzyRugf(int newId, ObjectDatabase db): base(1718056257, newId, db)
        {
        }

        public PassiveUndeadGhoulFrenzyRugf(string newRawcode, ObjectDatabase db): base(1718056257, newRawcode, db)
        {
        }
    }
}