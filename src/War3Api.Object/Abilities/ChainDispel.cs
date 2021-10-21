using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ChainDispel : Ability
    {
        public ChainDispel(): base(1701339969)
        {
        }

        public ChainDispel(int newId): base(1701339969, newId)
        {
        }

        public ChainDispel(string newRawcode): base(1701339969, newRawcode)
        {
        }

        public ChainDispel(ObjectDatabase db): base(1701339969, db)
        {
        }

        public ChainDispel(int newId, ObjectDatabase db): base(1701339969, newId, db)
        {
        }

        public ChainDispel(string newRawcode, ObjectDatabase db): base(1701339969, newRawcode, db)
        {
        }
    }
}