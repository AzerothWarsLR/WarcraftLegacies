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
    public sealed class ItemRandomItem : Ability
    {
        public ItemRandomItem(): base(1769097537)
        {
        }

        public ItemRandomItem(int newId): base(1769097537, newId)
        {
        }

        public ItemRandomItem(string newRawcode): base(1769097537, newRawcode)
        {
        }

        public ItemRandomItem(ObjectDatabaseBase db): base(1769097537, db)
        {
        }

        public ItemRandomItem(int newId, ObjectDatabaseBase db): base(1769097537, newId, db)
        {
        }

        public ItemRandomItem(string newRawcode, ObjectDatabaseBase db): base(1769097537, newRawcode, db)
        {
        }
    }
}