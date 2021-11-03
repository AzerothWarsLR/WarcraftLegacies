using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PassiveHumanRiflemanPlusRangeRhri : Ability
    {
        public PassiveHumanRiflemanPlusRangeRhri(): base(1769105473)
        {
        }

        public PassiveHumanRiflemanPlusRangeRhri(int newId): base(1769105473, newId)
        {
        }

        public PassiveHumanRiflemanPlusRangeRhri(string newRawcode): base(1769105473, newRawcode)
        {
        }

        public PassiveHumanRiflemanPlusRangeRhri(ObjectDatabase db): base(1769105473, db)
        {
        }

        public PassiveHumanRiflemanPlusRangeRhri(int newId, ObjectDatabase db): base(1769105473, newId, db)
        {
        }

        public PassiveHumanRiflemanPlusRangeRhri(string newRawcode, ObjectDatabase db): base(1769105473, newRawcode, db)
        {
        }
    }
}