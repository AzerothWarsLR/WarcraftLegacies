using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class RexxarSummonBear : Ability
    {
        public RexxarSummonBear(): base(1735619137)
        {
        }

        public RexxarSummonBear(int newId): base(1735619137, newId)
        {
        }

        public RexxarSummonBear(string newRawcode): base(1735619137, newRawcode)
        {
        }

        public RexxarSummonBear(ObjectDatabase db): base(1735619137, db)
        {
        }

        public RexxarSummonBear(int newId, ObjectDatabase db): base(1735619137, newId, db)
        {
        }

        public RexxarSummonBear(string newRawcode, ObjectDatabase db): base(1735619137, newRawcode, db)
        {
        }
    }
}