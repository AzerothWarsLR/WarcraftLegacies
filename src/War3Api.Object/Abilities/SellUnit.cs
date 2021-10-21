using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class SellUnit : Ability
    {
        public SellUnit(): base(1685418817)
        {
        }

        public SellUnit(int newId): base(1685418817, newId)
        {
        }

        public SellUnit(string newRawcode): base(1685418817, newRawcode)
        {
        }

        public SellUnit(ObjectDatabase db): base(1685418817, db)
        {
        }

        public SellUnit(int newId, ObjectDatabase db): base(1685418817, newId, db)
        {
        }

        public SellUnit(string newRawcode, ObjectDatabase db): base(1685418817, newRawcode, db)
        {
        }
    }
}