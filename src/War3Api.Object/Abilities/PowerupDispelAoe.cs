using System;
using System.Collections.Generic;
using System.Linq;
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

        public PowerupDispelAoe(ObjectDatabase db): base(1768181825, db)
        {
        }

        public PowerupDispelAoe(int newId, ObjectDatabase db): base(1768181825, newId, db)
        {
        }

        public PowerupDispelAoe(string newRawcode, ObjectDatabase db): base(1768181825, newRawcode, db)
        {
        }
    }
}