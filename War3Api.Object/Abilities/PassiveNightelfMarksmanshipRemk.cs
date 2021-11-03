using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class PassiveNightelfMarksmanshipRemk : Ability
    {
        public PassiveNightelfMarksmanshipRemk(): base(1802331457)
        {
        }

        public PassiveNightelfMarksmanshipRemk(int newId): base(1802331457, newId)
        {
        }

        public PassiveNightelfMarksmanshipRemk(string newRawcode): base(1802331457, newRawcode)
        {
        }

        public PassiveNightelfMarksmanshipRemk(ObjectDatabase db): base(1802331457, db)
        {
        }

        public PassiveNightelfMarksmanshipRemk(int newId, ObjectDatabase db): base(1802331457, newId, db)
        {
        }

        public PassiveNightelfMarksmanshipRemk(string newRawcode, ObjectDatabase db): base(1802331457, newRawcode, db)
        {
        }
    }
}