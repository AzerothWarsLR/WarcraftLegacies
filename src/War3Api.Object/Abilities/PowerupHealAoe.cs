using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PowerupHealAoe : Ability
    {
        public PowerupHealAoe(): base(845697089)
        {
        }

        public PowerupHealAoe(int newId): base(845697089, newId)
        {
        }

        public PowerupHealAoe(string newRawcode): base(845697089, newRawcode)
        {
        }

        public PowerupHealAoe(ObjectDatabase db): base(845697089, db)
        {
        }

        public PowerupHealAoe(int newId, ObjectDatabase db): base(845697089, newId, db)
        {
        }

        public PowerupHealAoe(string newRawcode, ObjectDatabase db): base(845697089, newRawcode, db)
        {
        }
    }
}