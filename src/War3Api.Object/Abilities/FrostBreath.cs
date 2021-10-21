using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FrostBreath : Ability
    {
        public FrostBreath(): base(1651664449)
        {
        }

        public FrostBreath(int newId): base(1651664449, newId)
        {
        }

        public FrostBreath(string newRawcode): base(1651664449, newRawcode)
        {
        }

        public FrostBreath(ObjectDatabase db): base(1651664449, db)
        {
        }

        public FrostBreath(int newId, ObjectDatabase db): base(1651664449, newId, db)
        {
        }

        public FrostBreath(string newRawcode, ObjectDatabase db): base(1651664449, newRawcode, db)
        {
        }
    }
}