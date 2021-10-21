using System;
using System.Collections.Generic;
using System.Linq;
using War3Net.Build.Object;
using War3Net.Common.Extensions;

namespace War3Api.Object.Abilities
{
    public sealed class ChainLightningItem : Ability
    {
        public ChainLightningItem(): base(1818446145)
        {
        }

        public ChainLightningItem(int newId): base(1818446145, newId)
        {
        }

        public ChainLightningItem(string newRawcode): base(1818446145, newRawcode)
        {
        }

        public ChainLightningItem(ObjectDatabase db): base(1818446145, db)
        {
        }

        public ChainLightningItem(int newId, ObjectDatabase db): base(1818446145, newId, db)
        {
        }

        public ChainLightningItem(string newRawcode, ObjectDatabase db): base(1818446145, newRawcode, db)
        {
        }
    }
}