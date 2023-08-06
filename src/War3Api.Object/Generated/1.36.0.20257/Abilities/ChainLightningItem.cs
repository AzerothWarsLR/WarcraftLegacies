using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using War3Api.Object.Abilities;
using War3Api.Object.Enums;
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

        public ChainLightningItem(ObjectDatabaseBase db): base(1818446145, db)
        {
        }

        public ChainLightningItem(int newId, ObjectDatabaseBase db): base(1818446145, newId, db)
        {
        }

        public ChainLightningItem(string newRawcode, ObjectDatabaseBase db): base(1818446145, newRawcode, db)
        {
        }
    }
}