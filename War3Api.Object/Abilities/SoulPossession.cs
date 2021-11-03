using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SoulPossession : Ability
    {
        public SoulPossession(): base(1970238273)
        {
        }

        public SoulPossession(int newId): base(1970238273, newId)
        {
        }

        public SoulPossession(string newRawcode): base(1970238273, newRawcode)
        {
        }

        public SoulPossession(ObjectDatabase db): base(1970238273, db)
        {
        }

        public SoulPossession(int newId, ObjectDatabase db): base(1970238273, newId, db)
        {
        }

        public SoulPossession(string newRawcode, ObjectDatabase db): base(1970238273, newRawcode, db)
        {
        }
    }
}