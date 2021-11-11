using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PermanentHitPointBonusSmall : Ability
    {
        public PermanentHitPointBonusSmall(): base(2020624705)
        {
        }

        public PermanentHitPointBonusSmall(int newId): base(2020624705, newId)
        {
        }

        public PermanentHitPointBonusSmall(string newRawcode): base(2020624705, newRawcode)
        {
        }

        public PermanentHitPointBonusSmall(ObjectDatabase db): base(2020624705, db)
        {
        }

        public PermanentHitPointBonusSmall(int newId, ObjectDatabase db): base(2020624705, newId, db)
        {
        }

        public PermanentHitPointBonusSmall(string newRawcode, ObjectDatabase db): base(2020624705, newRawcode, db)
        {
        }
    }
}