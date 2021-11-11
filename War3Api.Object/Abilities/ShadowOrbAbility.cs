using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ShadowOrbAbility : Ability
    {
        public ShadowOrbAbility(): base(1852066113)
        {
        }

        public ShadowOrbAbility(int newId): base(1852066113, newId)
        {
        }

        public ShadowOrbAbility(string newRawcode): base(1852066113, newRawcode)
        {
        }

        public ShadowOrbAbility(ObjectDatabase db): base(1852066113, db)
        {
        }

        public ShadowOrbAbility(int newId, ObjectDatabase db): base(1852066113, newId, db)
        {
        }

        public ShadowOrbAbility(string newRawcode, ObjectDatabase db): base(1852066113, newRawcode, db)
        {
        }
    }
}