using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ShadowSight : Ability
    {
        public ShadowSight(): base(1936225089)
        {
        }

        public ShadowSight(int newId): base(1936225089, newId)
        {
        }

        public ShadowSight(string newRawcode): base(1936225089, newRawcode)
        {
        }

        public ShadowSight(ObjectDatabase db): base(1936225089, db)
        {
        }

        public ShadowSight(int newId, ObjectDatabase db): base(1936225089, newId, db)
        {
        }

        public ShadowSight(string newRawcode, ObjectDatabase db): base(1936225089, newRawcode, db)
        {
        }
    }
}