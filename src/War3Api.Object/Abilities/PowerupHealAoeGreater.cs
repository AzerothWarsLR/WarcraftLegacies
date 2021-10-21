using System;
using System.Collections.Generic;
using System.Linq;
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

        public PowerupHealAoeGreater(ObjectDatabase db): base(862474305, db)
        {
        }

        public PowerupHealAoeGreater(int newId, ObjectDatabase db): base(862474305, newId, db)
        {
        }

        public PowerupHealAoeGreater(string newRawcode, ObjectDatabase db): base(862474305, newRawcode, db)
        {
        }
    }
}