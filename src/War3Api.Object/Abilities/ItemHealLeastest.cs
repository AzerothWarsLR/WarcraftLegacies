using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ItemHealLeastest : Ability
    {
        public ItemHealLeastest(): base(2020100417)
        {
        }

        public ItemHealLeastest(int newId): base(2020100417, newId)
        {
        }

        public ItemHealLeastest(string newRawcode): base(2020100417, newRawcode)
        {
        }

        public ItemHealLeastest(ObjectDatabase db): base(2020100417, db)
        {
        }

        public ItemHealLeastest(int newId, ObjectDatabase db): base(2020100417, newId, db)
        {
        }

        public ItemHealLeastest(string newRawcode, ObjectDatabase db): base(2020100417, newRawcode, db)
        {
        }
    }
}