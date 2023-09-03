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
    public sealed class SellItem : Ability
    {
        public SellItem(): base(1684632385)
        {
        }

        public SellItem(int newId): base(1684632385, newId)
        {
        }

        public SellItem(string newRawcode): base(1684632385, newRawcode)
        {
        }

        public SellItem(ObjectDatabaseBase db): base(1684632385, db)
        {
        }

        public SellItem(int newId, ObjectDatabaseBase db): base(1684632385, newId, db)
        {
        }

        public SellItem(string newRawcode, ObjectDatabaseBase db): base(1684632385, newRawcode, db)
        {
        }
    }
}