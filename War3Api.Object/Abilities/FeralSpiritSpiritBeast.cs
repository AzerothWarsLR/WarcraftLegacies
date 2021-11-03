using System;
using System.Collections.Generic;
using System.Linq;
using War3Api.Object.Abilities;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class FeralSpiritSpiritBeast : Ability
    {
        public FeralSpiritSpiritBeast(): base(947077953)
        {
        }

        public FeralSpiritSpiritBeast(int newId): base(947077953, newId)
        {
        }

        public FeralSpiritSpiritBeast(string newRawcode): base(947077953, newRawcode)
        {
        }

        public FeralSpiritSpiritBeast(ObjectDatabase db): base(947077953, db)
        {
        }

        public FeralSpiritSpiritBeast(int newId, ObjectDatabase db): base(947077953, newId, db)
        {
        }

        public FeralSpiritSpiritBeast(string newRawcode, ObjectDatabase db): base(947077953, newRawcode, db)
        {
        }
    }
}