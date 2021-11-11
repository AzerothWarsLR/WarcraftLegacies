using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class MoonGlaiveNoResearch : Ability
    {
        public MoonGlaiveNoResearch(): base(1919380801)
        {
        }

        public MoonGlaiveNoResearch(int newId): base(1919380801, newId)
        {
        }

        public MoonGlaiveNoResearch(string newRawcode): base(1919380801, newRawcode)
        {
        }

        public MoonGlaiveNoResearch(ObjectDatabase db): base(1919380801, db)
        {
        }

        public MoonGlaiveNoResearch(int newId, ObjectDatabase db): base(1919380801, newId, db)
        {
        }

        public MoonGlaiveNoResearch(string newRawcode, ObjectDatabase db): base(1919380801, newRawcode, db)
        {
        }
    }
}