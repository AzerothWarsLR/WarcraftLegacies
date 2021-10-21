using System;
using System.Collections.Generic;
using System.Linq;
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

        public CairneShockWave(ObjectDatabase db): base(846417729, db)
        {
        }

        public CairneShockWave(int newId, ObjectDatabase db): base(846417729, newId, db)
        {
        }

        public CairneShockWave(string newRawcode, ObjectDatabase db): base(846417729, newRawcode, db)
        {
        }
    }
}