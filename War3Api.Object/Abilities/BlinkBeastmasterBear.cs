using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class BlinkBeastmasterBear : Ability
    {
        public BlinkBeastmasterBear(): base(1818381889)
        {
        }

        public BlinkBeastmasterBear(int newId): base(1818381889, newId)
        {
        }

        public BlinkBeastmasterBear(string newRawcode): base(1818381889, newRawcode)
        {
        }

        public BlinkBeastmasterBear(ObjectDatabase db): base(1818381889, db)
        {
        }

        public BlinkBeastmasterBear(int newId, ObjectDatabase db): base(1818381889, newId, db)
        {
        }

        public BlinkBeastmasterBear(string newRawcode, ObjectDatabase db): base(1818381889, newRawcode, db)
        {
        }
    }
}