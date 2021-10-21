using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MoonGlaive : Ability
    {
        public MoonGlaive(): base(1818717505)
        {
        }

        public MoonGlaive(int newId): base(1818717505, newId)
        {
        }

        public MoonGlaive(string newRawcode): base(1818717505, newRawcode)
        {
        }

        public MoonGlaive(ObjectDatabase db): base(1818717505, db)
        {
        }

        public MoonGlaive(int newId, ObjectDatabase db): base(1818717505, newId, db)
        {
        }

        public MoonGlaive(string newRawcode, ObjectDatabase db): base(1818717505, newRawcode, db)
        {
        }
    }
}